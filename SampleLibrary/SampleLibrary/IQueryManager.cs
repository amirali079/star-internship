namespace SampleLibrary;

public interface IQueryManager
{
    HashSet<string> Search(string? query);
}