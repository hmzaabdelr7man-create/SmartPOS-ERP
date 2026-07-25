namespace SmartPOS.Shared.Configuration;

using SmartPOS.Shared.Enums;

/// <summary>
/// Contains the configuration options for the printers used by the application.
/// </summary>
public sealed class PrinterOptions
{
    /// <summary>Gets the configuration section name used to bind these options.</summary>
    public const string SectionName = "Printer";

    /// <summary>Gets or sets the name of the printer used for receipts.</summary>
    public string ReceiptPrinterName { get; set; } = string.Empty;

    /// <summary>Gets or sets the name of the printer used for reports.</summary>
    public string ReportPrinterName { get; set; } = string.Empty;

    /// <summary>Gets or sets the paper size used when printing receipts.</summary>
    public PaperSize ReceiptPaperSize { get; set; } = PaperSize.Receipt80mm;

    /// <summary>Gets or sets the number of copies printed for each receipt.</summary>
    public int ReceiptCopies { get; set; } = 1;

    /// <summary>Gets or sets a value indicating whether a print dialog should be shown before printing.</summary>
    public bool ShowPrintDialog { get; set; } = false;

    /// <summary>Gets or sets a value indicating whether a print preview should be shown before printing.</summary>
    public bool ShowPreview { get; set; } = true;
}
