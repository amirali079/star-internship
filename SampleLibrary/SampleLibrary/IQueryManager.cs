namespace SampleLibrary;

public interface IQueryManager
{
    void SetInvertedIndex(Dictionary<string, HashSet<string>> invertedIndex);
    HashSet<string> Search(string? query);
}