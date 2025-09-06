namespace Contracts;

public interface IPdfGenerator
{
    Task GenerateAsync(string text, string filename, CancellationToken cancellationToken);
}