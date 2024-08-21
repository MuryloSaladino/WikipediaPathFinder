using System.Text.RegularExpressions;

public static class HTMLReader
{
    private static Regex anchorRegex = new("<a.*>");

    public static string[] GetLinks(string html)
    {
        throw new NotImplementedException();
    }
}