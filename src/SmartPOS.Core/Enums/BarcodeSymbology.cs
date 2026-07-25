namespace SmartPOS.Core.Enums;

/// <summary>
/// Identifies the barcode symbology used to encode a value.
/// </summary>
public enum BarcodeSymbology
{
    /// <summary>EAN-13 linear barcode for retail products.</summary>
    Ean13 = 0,

    /// <summary>Code 128 linear barcode for dense alphanumeric data.</summary>
    Code128 = 1,

    /// <summary>QR Code two-dimensional barcode.</summary>
    QrCode = 2,
}
