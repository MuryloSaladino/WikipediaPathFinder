using System.Text.RegularExpressions;

public static class HTMLReader
{
    private static readonly Regex AnchorRegex = new(@"<a\s+[^>]*href\s*=\s*['""][^'""]*['""][^>]*>(.*?)</a>");

    public static string[] GetLinks(string html)
    {
        return AnchorRegex
            .Matches(html)
            .Select(x => x.Value)
            .ToArray();
    }
}