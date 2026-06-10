namespace ThreadPoolApp;

public class Printer
{
    private object threadLock = new object();

    public void PrintNumbers()
    {
        lock(threadLock)
        {
            Console.WriteLine("-> {0} is executing PrintNumbers", Thread.CurrentThread.Name);

            for(var i = 0; i < 10; i++)
            {
                // Put thread to sleep for a random amount of time.
                Random r = new Random();
                Thread.Sleep(1000);
                Console.Write("{0}, ", i);
            }
            Console.WriteLine();
        }
    }
}