namespace SampleLibrary.Test;

public class FileReaderTest : IDisposable
{
    private const string Dir = @"../../../../test";

    public void Dispose()
    {
        foreach (var file in Directory.GetFiles(Dir))
            File.Delete(file);
    }

    private static void CreateFiles()
    {
        if (!Directory.Exists(Dir)) Directory.CreateDirectory(Dir);

        var pathString1 = Path.Combine(Dir, "file1");
        var pathString2 = Path.Combine(Dir, "file2");

        using var fileStream1 = new StreamWriter(pathString1);
        fileStream1.Write("test file1");

        using var fileStream2 = new StreamWriter(pathString2);
        fileStream2.Write("test file2");
    }

    [Fact]
    public void ReadFile_Test()
    {
        CreateFiles();
        var fileReader = new FileReader();
        var expected = new Dictionary<string, string>
        {
            { "file1", "test file1" },
            { "file2", "test file2" }
        };

        var actual = fileReader.ReadFile(@"../../../../test");

        Assert.Equal(expected, actual);
    }
}