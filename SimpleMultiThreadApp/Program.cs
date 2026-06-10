using SimpleMultiThreadApp;

Console.WriteLine("*****  The Thread App *****\n");
Console.WriteLine("Do you want [1] or [2] threads?");
string threadCount = Console.ReadLine();

Thread primaryThread = Thread.CurrentThread;
primaryThread.Name = "Primary";

Console.WriteLine("{0} is executing Main()", Thread.CurrentThread.Name);

Printer p = new Printer();

switch(threadCount)
{
    case "2":
        Thread backGroundThread = new Thread(new ThreadStart(p.PrintNumbers));
        backGroundThread.Name = "Secondary";
        backGroundThread.Start();
        break;
    case "1":
        p.PrintNumbers();
        break;
    default:
        Console.WriteLine("Since i don't know what you want, you get one thread.");
        goto case "1";
}

//Do some additional work.
Console.WriteLine("This is on the main thread, and we are finished.");
Console.ReadLine();