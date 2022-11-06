using System.Text.RegularExpressions;

namespace SampleLibrary;

public class FileReader : IFileReader
{
    public Dictionary<string, string> ReadFile(string path)
    {
        return Directory.GetFiles(path).ToDictionary(Path.GetFileName, File.ReadAllText);
    }
}