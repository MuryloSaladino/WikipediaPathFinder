using System.Text.RegularExpressions;

public static partial class HTMLReader
{
    [GeneratedRegex(@"href=""/wiki/[^"":]*""")]
    private static partial Regex MyRegex();

    private static readonly Regex AnchorRegex = MyRegex();


    public static string[] GetWikipediaLinks(string html)
    {
        return AnchorRegex
            .Matches(html)
            .Select(x => x.Value[12..(x.Value.Length-1)])
            .ToArray();
    }
}