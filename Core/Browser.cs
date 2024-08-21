using System.Net;

public static class Browser
{
    private static readonly HttpClient Client = new(
        new HttpClientHandler {
            Proxy = new WebProxy {
                Address = new Uri("http://rb-proxy-ca1.bosch.com:8080"),
                Credentials = new NetworkCredential("disrct", "etsps2024401")
            }
        }
    );

    public static async Task<string> GetPage(string link)
    {
        var response = await Client.GetAsync(link);
        return await response.Content.ReadAsStringAsync();
    }
}

public class LinkNotFoundException : Exception {}