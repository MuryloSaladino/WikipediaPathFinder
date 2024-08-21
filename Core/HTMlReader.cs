using System.Text.RegularExpressions;

public static class HTMLReader
{
    private static readonly Regex AnchorRegex = new(@"<a\s+[^>]*href\s*=\s*['""][^'""]*['""][^>]*>");

    public static string[] GetWikipediaLinks(string html)
    {
        int start = html.IndexOf("<main");
        int end = html.IndexOf("</main>") - start;

        return AnchorRegex
            .Matches(html.Substring(start, end))
            .Select(x => x.Value)
            .ToArray();
    }
}