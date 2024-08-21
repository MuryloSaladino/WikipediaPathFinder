public static class WikipediaFinder
{
    private static readonly string BaseURL = "https://pt.wikipedia.org/wiki/"; 

    public static async Task<string> Find(string start, string end)
    {
        var queue = new Queue<string>();
        var pathMap = new Dictionary<string, string>();
        var visited = new HashSet<string>();

        queue.Enqueue(start);

        while(queue.Count > 0)
        {
            var current = queue.Dequeue();
            if(visited.Contains(current)) continue;
            visited.Add(current);

            if(current == end) break;
        
            var page = await Browser.GetPage(BaseURL + current);
            var connections = HTMLReader.GetWikipediaLinks(page);

            foreach (var connection in connections)
            {
                if(visited.Contains(connection)) continue;
                
                if(!pathMap.ContainsKey(connection))
                    pathMap.Add(connection, current);
                queue.Enqueue(connection);
            }
        }

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
