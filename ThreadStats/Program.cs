Console.WriteLine("***** Thread status *****");

var primaryThread = Thread.CurrentThread;
primaryThread.Name = "PrimaryThread";

Console.WriteLine(primaryThread.Name);
Console.WriteLine($"Is Alive: {primaryThread.IsAlive}");
Console.WriteLine($"Priority: {primaryThread.Priority}");
Console.WriteLine($"Thread state: {primaryThread.ThreadState}");
Console.WriteLine($"Managed ID: {primaryThread.ManagedThreadId}");
Console.ReadLine();
