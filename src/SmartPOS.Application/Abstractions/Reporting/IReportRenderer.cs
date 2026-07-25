namespace SmartPOS.Application.Abstractions.Reporting;

using System.IO;

/// <summary>
/// Renders report definitions into the requested output format.
/// </summary>
public interface IReportRenderer
{
    /// <summary>Renders the supplied report definition into a stream.</summary>
    /// <param name="definition">The report definition to render.</param>
    /// <param name="format">The output format to produce.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A stream containing the rendered report.</returns>
    Task<Stream> RenderAsync(IReportDefinition definition, ReportFormat format, CancellationToken cancellationToken = default);
}
