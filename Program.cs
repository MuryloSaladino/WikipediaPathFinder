
var page = await Browser.GetPage("https://pt.wikipedia.org/wiki/Audi");
var links = HTMLReader.GetWikipediaLinks(page);

foreach(var link in links)
    Console.WriteLine(link);