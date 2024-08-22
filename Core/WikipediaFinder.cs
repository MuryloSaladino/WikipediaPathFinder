using System.Web;

public static class WikipediaFinder
{
    private static readonly string BaseURL = "https://pt.wikipedia.org/wiki/"; 

    public static async Task<string> Find(string start, string end)
    {
        start = HttpUtility.UrlEncode(start);
        end = HttpUtility.UrlEncode(end);

        var queue = new Queue<string>();
        var pathMap = new Dictionary<string, string>();
        var visited = new HashSet<string>();
        bool found = false;

        var initialPage = await Browser.GetPage(BaseURL + start);
        var initialConnections = HTMLReader.GetWikipediaLinks(initialPage);
        for (int i = 0; i < initialConnections.Length; i++)
            queue.Enqueue(initialConnections[i]);

        Parallel.For(0, 10, (index) => {
            while(true)
            {
                string current;
                
                lock(queue)
                {
                    if(found) 
                    {
                        break;
                    }
                    current = queue.Dequeue();
                }
                Console.WriteLine(current);
                
                lock(visited)
                {
                    if(visited.Contains(current)) continue;
                    visited.Add(current);
                }

                if(end == current) 
                {
                    found = true;
                }

                var page = Browser.GetPage(BaseURL + current);
                page.Wait();
                var connections = HTMLReader.GetWikipediaLinks(page.Result);

                foreach (var connection in connections)
                {
                    if(visited.Contains(connection)) continue;
                    // if(!char.IsDigit(end[0]) && char.IsDigit(connection[0])) continue;
                    
                    lock(pathMap)
                    {
                        if(!pathMap.ContainsKey(connection))
                            pathMap.Add(connection, current);
                        queue.Enqueue(connection);
                    }
                }
            }
        });

        var path = end;
        var iterator = pathMap[end];
        while(iterator != start)
        {
            path = iterator + "=> " + path;
            iterator = pathMap[iterator];
        }

        return $"{start} => {path}";
    }
}