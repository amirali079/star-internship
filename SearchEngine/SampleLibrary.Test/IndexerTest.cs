namespace SampleLibrary.Test;

public class IndexerTest
{
    [Fact]
    public void GetInvertedIndex_Test()
    {
        var expected = new Dictionary<string, HashSet<string>>
        {
            { "TEST", new HashSet<string> { "file1", "file2" } },
            { "ONE", new HashSet<string> { "file1" } },
            { "TWO", new HashSet<string> { "file2" } },
        };
        var indexer = new Indexer();

        var actual  = indexer.GetInvertedIndex(
            new Dictionary<string, string>
        {
            { "file1", "test one" },
            { "file2", "test two" }
        }
            );
        
        Assert.Equal(expected, actual );
    }
}