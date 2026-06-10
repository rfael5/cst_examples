using MultiThreadedPrinting;

Console.WriteLine("***** Synchronizing Threads *****\n");

Printer p = new Printer();

//Create 10 threads all pointing to the same method on the
//same object (Printer p /\).

Thread[] threads = new Thread[10];

for (int i = 0; i < 10; i++)
{
    threads[i] = new Thread(new ThreadStart(p.PrintNumbers))
    {
        Name = $"Worker thread #{i}"
    };
}

//Start each thread.

foreach (Thread t in threads)
{
    t.Start();
}

Console.ReadLine();