using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Logging;
using SmartPOS.Contracts.Services;

namespace SmartPOS.Infrastructure.Settings;

/// <summary>
/// File-backed implementation of <see cref="ISettingsService"/>. Reads from
/// the user override file and writes changes back so shipped defaults remain
/// untouched.
/// </summary>
public sealed class SettingsService : ISettingsService, IAsyncDisposable
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private readonly string _filePath;
    private readonly SemaphoreSlim _gate = new(1, 1);
    private readonly ILogger<SettingsService> _logger;

    /// <summary>Initializes a new instance with the logger and file path.</summary>
    public SettingsService(ILogger<SettingsService> logger, string filePath)
    {
        _logger = logger;
        _filePath = filePath;
    }

    /// <inheritdoc />
    public async Task<T> GetAsync<T>(CancellationToken cancellationToken = default) where T : new()
    {
        await _gate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            var root = await LoadRootAsync(cancellationToken).ConfigureAwait(false);
            var sectionName = GetSectionName<T>();
            if (root.TryGetPropertyValue(sectionName, out var node) && node is not null)
            {
                return node.Deserialize<T>(JsonOptions) ?? new T();
            }

            return new T();
        }
        finally
        {
            _gate.Release();
        }
    }

    /// <inheritdoc />
    public async Task SetAsync<T>(T value, CancellationToken cancellationToken = default) where T : class
    {
        var sectionName = GetSectionName<T>();
        await _gate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            var root = await LoadRootAsync(cancellationToken).ConfigureAwait(false);
            root[sectionName] = JsonSerializer.SerializeToNode(value, JsonOptions);
            await PersistAsync(root, cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _gate.Release();
        }
    }

    private static string GetSectionName<T>()
    {
        var sectionNameProperty = typeof(T).GetProperty("SectionName");
        if (sectionNameProperty is not null && sectionNameProperty.GetValue(null) is string name)
        {
            return name;
        }

        return typeof(T).Name;
    }

    private async Task<JsonObject> LoadRootAsync(CancellationToken cancellationToken)
    {
        if (!File.Exists(_filePath))
        {
            return new JsonObject();
        }

        var text = await File.ReadAllTextAsync(_filePath, cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(text))
        {
            return new JsonObject();
        }

        return JsonNode.Parse(text)?.AsObject() ?? new JsonObject();
    }

    private async Task PersistAsync(JsonObject root, CancellationToken cancellationToken)
    {
        try
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            await File.WriteAllTextAsync(_filePath, root.ToJsonString(JsonOptions), cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to persist settings to {FilePath}.", _filePath);
        }
    }

    /// <summary>Releases the concurrency gate.</summary>
    public ValueTask DisposeAsync()
    {
        _gate.Dispose();
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}
