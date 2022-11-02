namespace SampleLibrary;

public interface IFileReader
{
    Dictionary<string, string> ReadFile(string path);
}