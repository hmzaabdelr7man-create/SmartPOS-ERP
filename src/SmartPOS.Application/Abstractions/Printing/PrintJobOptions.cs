namespace SmartPOS.Application.Abstractions.Printing;

using SmartPOS.Shared.Enums;

/// <summary>
/// Describes the options used when submitting a print job.
/// </summary>
public sealed class PrintJobOptions
{
    /// <summary>Gets or sets the name of the printer that should receive the job.</summary>
    public string PrinterName { get; set; } = string.Empty;

    /// <summary>Gets or sets the paper size to use for the job.</summary>
    public PaperSize PaperSize { get; set; } = PaperSize.Receipt80mm;

    /// <summary>Gets or sets the number of copies to print.</summary>
    public int Copies { get; set; } = 1;

    /// <summary>Gets or sets a value indicating whether a print dialog should be shown before printing.</summary>
    public bool ShowDialog { get; set; }

    /// <summary>Gets or sets a value indicating whether a print preview should be shown before printing.</summary>
    public bool ShowPreview { get; set; } = true;

    /// <summary>Gets or sets the title of the print job.</summary>
    public string Title { get; set; } = string.Empty;
}
