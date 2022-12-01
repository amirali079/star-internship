namespace SampleLibrary.Test;

public class QueryManagerTest
{
    private readonly Dictionary<string, HashSet<string>> _invertedIndex = new()
    {
        { "A", new HashSet<string> { "f1", "f2", "f3" } },
        { "B", new HashSet<string> { "f1", "f2", "f3" } },
        { "C", new HashSet<string> { "f1", "f2" } },
        { "D", new HashSet<string> { "f1", "f3" } },
        { "E", new HashSet<string> { "f2", "f3" } },
        { "F", new HashSet<string> { "f1" } },
        { "G", new HashSet<string> { "f2" } },
        { "H", new HashSet<string> { "f3" } },
        { "I", new HashSet<string> { "f4" } }
    };

    [Theory]
    [InlineData("A B", "f1 f2 f3")]
    [InlineData("+E +D +I", "f1 f2 f3 f4")]
    [InlineData("A B +F +G", "f1 f2")]
    [InlineData("A B +F +G -I", "f1 f2")]
    [InlineData("A B +F +G -D", "f2")]
    public void Search_token(string input, string expectedToken)
    {
        var expected = new HashSet<string>(expectedToken.Split(" "));
        var queryManager = new QueryManager();
        queryManager.SetInvertedIndex(_invertedIndex);
        var actual = queryManager.Search(input);

        Assert.Equal(expected, actual);
    }
}