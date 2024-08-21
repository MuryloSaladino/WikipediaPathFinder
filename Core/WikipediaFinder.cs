public static class WikipediaFinder
{
    private static readonly string BaseURL = "https://pt.wikipedia.org/wiki/"; 

    public static string Find(string start, string end)
    {
        var queue = new Queue<Point>();
        var closestMap = new Dictionary<Point, Point>();

        queue.Enqueue(new Point(start));

        while(queue.Count > 0)
        {
            var current = queue.Dequeue();
            if(current.Visited) continue;
            current.Visited = true;

            if(current.Value == end) break;
        
        }
    }
}

public class Point(string value)
{
    public string Value = value;
    public bool Visited = false;
    public string[] Connections;
}
