namespace SmartPOS.Application.Abstractions.Printing;

using System.IO;

/// <summary>
/// Submits print jobs to a physical or virtual printer.
/// </summary>
public interface IPrintService
{
    /// <summary>Prints the supplied document stream using the specified options.</summary>
    /// <param name="document">A stream containing the document to print.</param>
    /// <param name="options">The options that describe how the document should be printed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous print operation.</returns>
    Task PrintAsync(Stream document, PrintJobOptions options, CancellationToken cancellationToken = default);
}
