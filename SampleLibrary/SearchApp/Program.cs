using SampleLibrary;

class Program
{
    public static void Main(string[] args)
    {
        var fileReader = new FileReader();
        var indexer = new Indexer();
        var queryManager = new QueryManager(){InvertedIndex=indexer.
            GetInvertedIndex(fileReader.ReadFile(@"../../../../EnglishData"))};

        // foreach (var e in queryManager.InvertedIndex.Keys)
        // {
        //     Console.WriteLine(e);
        // }
        //

        var result = queryManager.Search(Console.ReadLine().ToUpper());

        Console.WriteLine(result.Count);
        foreach (var element in result)
        {
            Console.WriteLine(element);
        }

    }
}