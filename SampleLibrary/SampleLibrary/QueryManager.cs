namespace SampleLibrary;

public class QueryManager : IQueryManager
{
    public Dictionary<string, HashSet<string>> InvertedIndex;

    public HashSet<string> Search(string? query)
    {
        var commands = query.Split(" ");

        var result = new HashSet<string>();

        var and = new List<HashSet<string>>();
        var or = new HashSet<string>();
        var not = new HashSet<string>();

        foreach (var word in commands)
        {
            if (word[0].Equals('+'))
            {
                InvertedIndex.TryGetValue(word[1..], out var keys);

                if (keys != null)
                    foreach (var element in keys)
                    {
                        or.Add(element);
                    }
            }
            else if (word[0].Equals('-'))
            {
                InvertedIndex.TryGetValue(word[1..], out var keys);
                if (keys != null)
                    foreach (var element in keys)
                    {
                        not.Add(element);
                    }
            }
            else
            {
                InvertedIndex.TryGetValue(word, out var keys);
                if (keys != null) and.Add(keys);
            }
        }

        if (!and.Count.Equals(0))
        {
            result = and[0];
            foreach (var set in and)
                result.IntersectWith(set);
        }
        else
            result = or;

        Console.WriteLine(or.Count);
        if (!or.Count.Equals(0))
            result.IntersectWith(or);
        
        

        foreach (var wordNot in not)
            result.RemoveWhere(word=>word.Equals(wordNot));

        return result;
    }
}