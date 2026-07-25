namespace SmartPOS.Application.Abstractions.Barcode;

using System.IO;
using SmartPOS.Shared.Enums;

/// <summary>
/// Generates barcode images from encoded values.
/// </summary>
public interface IBarcodeGenerator
{
    /// <summary>Generates a barcode image for the supplied value using the specified symbology.</summary>
    /// <param name="value">The value to encode in the barcode.</param>
    /// <param name="symbology">The symbology used to encode the value.</param>
    /// <param name="width">The width, in pixels, of the generated image.</param>
    /// <param name="height">The height, in pixels, of the generated image.</param>
    /// <returns>A PNG stream containing the generated barcode image.</returns>
    Stream Generate(string value, BarcodeSymbology symbology, int width, int height);
}
