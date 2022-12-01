namespace SampleLibrary;

public interface IIndexer
{
    Dictionary<string, HashSet<string>> GetInvertedIndex(Dictionary<string, string> docs);
}