using System.Text.RegularExpressions;

namespace SampleLibrary;

public class Indexer : IIndexer
{
    private readonly Dictionary<string, HashSet<string>> _invertedIndex = new Dictionary<string, HashSet<string>>();

    public Dictionary<string, HashSet<string>> GetInvertedIndex(Dictionary<string, string> docs)
    {
        foreach (var doc in docs.Keys)
        {
            var words = Regex.Replace(docs[doc], @"[^a-z A-Z]+", " ").ToUpper().Split(" ");

            foreach (var word in words)
            {
                if (_invertedIndex.ContainsKey(word))
                {
                    _invertedIndex[word].Add(doc);
                }
                else
                {
                    var docIds = new HashSet<string>();
                    docIds.Add(doc);
                    _invertedIndex.Add(word, docIds);
                }
            }
        }

        return _invertedIndex;
    }
}