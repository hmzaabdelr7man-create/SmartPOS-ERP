namespace SmartPOS.Barcode.Generators;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;
using SmartPOS.Application.Abstractions.Barcode;
using SmartPOS.Shared.Enums;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

/// <summary>
/// Generates barcode images using the ZXing and QRCoder libraries.
/// </summary>
public class BarcodeGenerator : IBarcodeGenerator
{
    /// <inheritdoc />
    public Stream Generate(string value, BarcodeSymbology symbology, int width, int height)
    {
        if (symbology == BarcodeSymbology.QrCode)
        {
            return GenerateQrCode(value, width, height);
        }

        return GenerateLinear(value, symbology, width, height);
    }

    private static Stream GenerateQrCode(string value, int width, int height)
    {
        using var generator = new QRCodeGenerator();
        using var data = generator.CreateQrCode(value, QRCodeGenerator.ECCLevel.M);
        var qrCode = new PngByteQRCode(data);
        var bytes = qrCode.GetGraphic(20);
        return new MemoryStream(bytes);
    }

    private static Stream GenerateLinear(string value, BarcodeSymbology symbology, int width, int height)
    {
        var format = symbology == BarcodeSymbology.Ean13 ? BarcodeFormat.EAN_13 : BarcodeFormat.CODE_128;
        var writer = new MultiFormatWriter();
        var matrix = writer.encode(value, format, width, height);
        var bitmap = ToBitmap(matrix, width, height);
        var stream = new MemoryStream();
        bitmap.Save(stream, ImageFormat.Png);
        bitmap.Dispose();
        stream.Position = 0;
        return stream;
    }

    private static Bitmap ToBitmap(BitMatrix matrix, int width, int height)
    {
        var bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                var on = matrix[x, y];
                bitmap.SetPixel(x, y, on ? Color.Black : Color.White);
            }
        }

        return bitmap;
    }
}
