using System.Text.RegularExpressions;

public static partial class HTMLReader
{
    [GeneratedRegex(@"href=""/wiki/[^"":]*""")]
    private static partial Regex MyRegex();

    private static readonly Regex AnchorRegex = MyRegex();


    public static string[] GetWikipediaLinks(string html)
    {
        int start = html.IndexOf("id=\"bodyContent\"");
        int end = html.IndexOf("id=\"Ver_também\"");
        if(end < 0) end = html.IndexOf("</main>");
        if(start < 0) start = html.IndexOf("<main");

        return AnchorRegex
            .Matches(html[start..end])
            .Select(x => x.Value[12..(x.Value.Length-1)])
            .ToArray();
    }
}