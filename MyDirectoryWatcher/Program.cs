FileSystemWatcher watcher = new FileSystemWatcher();

try
{
    watcher.Path = @".";
}
catch(Exception ex)
{
    Console.WriteLine(ex);
    return;
}

watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

watcher.Filter = "*.txt";

watcher.Changed += (s, e) => Console.WriteLine($"File: {e.FullPath} {e.ChangeType}!");
watcher.Created += (s, e) => Console.WriteLine($"File: {e.FullPath} {e.ChangeType}!");
watcher.Deleted += (s, e) => Console.WriteLine($"File: {e.FullPath} {e.ChangeType}!");

watcher.Renamed += (s, e) => Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");

watcher.EnableRaisingEvents = true;

Console.WriteLine(@"Press 'q' to quit app.");

using(var sw = File.CreateText("Test.txt"))
{
    await Task.Delay(3000);
    sw.Write("This is some text");
}
await Task.Delay(3000);
File.Move("Test.txt", "Test2.txt");
await Task.Delay(3000);
File.Delete("Test2.txt");

while(Console.Read() != 'q');