namespace SmartPOS.Reporting.Rendering;

using System.IO;
using SmartPOS.Application.Abstractions.Reporting;

/// <summary>
/// A stub implementation of <see cref="IReportRenderer" /> that uses QuestPDF to render reports.
/// </summary>
public class QuestPdfReportRenderer : IReportRenderer
{
    /// <inheritdoc />
    public Task<Stream> RenderAsync(IReportDefinition definition, ReportFormat format, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var content = $"{definition.Title}{Environment.NewLine}Key: {definition.Key}";
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        Stream stream = new MemoryStream(buffer);
        return Task.FromResult(stream);
    }
}
