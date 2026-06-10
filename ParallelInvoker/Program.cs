using System.Text;
using System.Net;

string _theEbook = "";
GetBook();
Console.WriteLine("Downloading...");
Console.ReadLine();

void GetBook()
{
    WebClient wc = new WebClient();

    wc.DownloadStringCompleted += (s, eArgs) =>
    {
        _theEbook = eArgs.Result;
        Console.WriteLine("Download completed.");
        GetStats();
    };

    wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/2413/2413-0.txt"));
}

string[] FindTenMostCommon(string[] words)
{
    var frequencyOrder = from word in words
                        where word.Length > 6
                        group word by word into g 
                        orderby g.Count() descending 
                        select g.Key;
    
    string[] commonWords = (frequencyOrder.Take(10)).ToArray();
    return commonWords;
}

string FindLongestWord(string[] words)
{
    return (from w in words orderby w.Length descending select w).FirstOrDefault();
}

void GetStats()
{
    string[] words = _theEbook.Split(
        new char[] {' ', '\u000A', ',', '.', ';', ':', '-', '?', '/'}, 
        StringSplitOptions.RemoveEmptyEntries);
    string[] tenMostCommon = null;
    string biggestWord = string.Empty;

    Parallel.Invoke(
        () => {tenMostCommon = FindTenMostCommon(words);},
        () => {biggestWord = FindLongestWord(words);}
    );
    
    StringBuilder stringBuilder = new StringBuilder("The 10 most common words are:\n");
    foreach(string word in tenMostCommon)
    {
        stringBuilder.AppendLine(word);
    }
    stringBuilder.AppendFormat("The longest word is: {0}", biggestWord);
    stringBuilder.AppendLine();

    Console.WriteLine(stringBuilder.ToString(), "Book info");
}
