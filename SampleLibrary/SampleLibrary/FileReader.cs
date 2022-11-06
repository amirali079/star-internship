using System.Text.RegularExpressions;

namespace SampleLibrary;

public class FileReader : IFileReader
{
    public Dictionary<string, string> ReadFile(string path)
    {
        var fileEntries = Directory.GetFiles(path);
        
        var docs = fileEntries.ToDictionary(file => Regex.Replace(file, @"[^0-9]+", ""),
            File.ReadAllText);

        return docs;
    }
}