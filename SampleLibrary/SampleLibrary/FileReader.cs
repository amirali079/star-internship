namespace SampleLibrary;

public class FileReader : IFileReader
{
    public Dictionary<string, string> ReadFile(string path)
    {
        var fileEntries = Directory.GetFiles(path);
        var docs = fileEntries.ToDictionary(file => file, File.ReadAllText);

        return docs;
    }
}