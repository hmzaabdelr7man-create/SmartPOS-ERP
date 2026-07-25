namespace SmartPOS.Shared.Configuration;

/// <summary>
/// Contains the configuration options describing the company that operates the application.
/// </summary>
public sealed class CompanyOptions
{
    /// <summary>Gets the configuration section name used to bind these options.</summary>
    public const string SectionName = "Company";

    /// <summary>Gets or sets the legal name of the company.</summary>
    public string Name { get; set; } = "Smart POS ERP";

    /// <summary>Gets or sets the tax registration number of the company.</summary>
    public string TaxNumber { get; set; } = string.Empty;

    /// <summary>Gets or sets the postal address of the company.</summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>Gets or sets the contact phone number of the company.</summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>Gets or sets the contact email address of the company.</summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>Gets or sets the website address of the company.</summary>
    public string Website { get; set; } = string.Empty;

    /// <summary>Gets or sets the footer text printed at the bottom of receipts.</summary>
    public string ReceiptFooter { get; set; } = "Thank you for your business!";
}
