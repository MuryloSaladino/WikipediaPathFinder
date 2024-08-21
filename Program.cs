
var page = await Browser.GetPage("https://pt.wikipedia.org/wiki/Audi");
var links = HTMLReader.GetLinks(page);

foreach(var link in links)
    Console.WriteLine(link);