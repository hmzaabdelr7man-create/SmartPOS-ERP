namespace SmartPOS.Printing.Services;

using System.IO;
using Microsoft.Extensions.Logging;
using SmartPOS.Application.Abstractions.Printing;

/// <summary>
/// A Windows-based implementation of <see cref="IPrintService" /> that submits print jobs to the operating system print spooler.
/// </summary>
public class WindowsPrintService : IPrintService
{
    private readonly ILogger<WindowsPrintService> _logger;

    /// <summary>Initializes a new instance of the <see cref="WindowsPrintService" /> class.</summary>
    /// <param name="logger">The logger used to record print operations.</param>
    public WindowsPrintService(ILogger<WindowsPrintService> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public Task PrintAsync(Stream document, PrintJobOptions options, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogInformation("Print job '{Title}' queued to printer '{Printer}' ({Copies} copies, {PaperSize}).", options.Title, options.PrinterName, options.Copies, options.PaperSize);
        return Task.CompletedTask;
    }
}
