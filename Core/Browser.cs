using System.Net;

public static class Browser
{
    private static readonly HttpClient Client = new();

    public static async Task<string> GetPage(string link)
    {
        var response = await Client.GetAsync(link);
        return await response.Content.ReadAsStringAsync();
    }
}

public class LinkNotFoundException : Exception {}