namespace Contracts
{
    public interface IPdfGenerator
    {
        void Generate(string text, string filename);
    }
}
