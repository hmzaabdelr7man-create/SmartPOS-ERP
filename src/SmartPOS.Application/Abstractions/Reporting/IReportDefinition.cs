namespace SmartPOS.Application.Abstractions.Reporting;

/// <summary>
/// Identifies the format used to render a report.
/// </summary>
public enum ReportFormat
{
    /// <summary>Portable Document Format.</summary>
    Pdf,

    /// <summary>Plain text format.</summary>
    Text,

    /// <summary>HyperText Markup Language format.</summary>
    Html,
}

/// <summary>
/// Describes a report that can be rendered by an <see cref="IReportRenderer" />.
/// </summary>
public interface IReportDefinition
{
    /// <summary>Gets the user-facing title of the report.</summary>
    string Title { get; }

    /// <summary>Gets the culture-invariant identifier of the report.</summary>
    string Key { get; }

    /// <summary>Gets the data that should be rendered by the report.</summary>
    object? Data { get; }
}
