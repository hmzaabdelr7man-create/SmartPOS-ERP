namespace SmartPOS.Application.Abstractions.Reporting;

/// <summary>
/// The output format produced by an <see cref="IReportRenderer"/>.
/// </summary>
public enum ReportFormat
{
    /// <summary>Portable Document Format.</summary>
    Pdf = 0,

    /// <summary>Plain text, suitable for thermal printers.</summary>
    Text = 1,

    /// <summary>HTML preview shown in a browser control.</summary>
    Html = 2
}
