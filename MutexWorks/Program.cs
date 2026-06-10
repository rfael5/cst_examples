using System;
using System.Threading;

// class ExampleOne
// {
//     private static Mutex mut = new Mutex();
//     private const int numIterations = 1;
//     private const int numThreads = 3;

//     static void Main()
//     {
//         for(int i = 0; i < numThreads; i++)
//         {
//             Thread newThread = new Thread(new ThreadStart(ThreadProc));
//             newThread.Name = String.Format("Thread {0}", i + 1);
//             newThread.Start();
//         }
//     }

//     private static void ThreadProc()
//     {
//         for (int i = 0; i < numIterations; i++)
//         {
//             UseResource();
//         }
//     }

//     private static void UseResource()
//     {
//         Console.WriteLine("{0} is requesting the mutex", Thread.CurrentThread.Name);

//         mut.WaitOne();

//         Console.WriteLine("{0} has entered the protected area", Thread.CurrentThread.Name);

//         //Simulating some work.
//         Thread.Sleep(500);

//         Console.WriteLine("{0} is leaving the protected area", Thread.CurrentThread.Name);

//         mut.ReleaseMutex();

//         Console.WriteLine("{0} has released the mutex", Thread.CurrentThread.Name);
//     }
// }

class ExampleTwo
{
    private static Mutex mut = new Mutex();
    private const int numIterations = 1;
    private const int numThreads = 3;    

    static void Main()
    {
        ExampleTwo ex = new ExampleTwo();
        ex.StartThreads();
    }

    private void StartThreads()
    {
        for(int i = 0; i < numThreads; i++)
        {
            Thread newThread = new Thread(new ThreadStart(ThreadProc));
            newThread.Name = String.Format("Thread{0}", i + 1);
            newThread.Start();
        }
    }

    private static void ThreadProc()
    {
        for(int i = 0; i < numIterations; i++)
        {
            UseResource();
        }
    }

    private static void UseResource()
    {
        Console.WriteLine("{0} is requesting the mutex", Thread.CurrentThread.Name);
        if(mut.WaitOne(1000))
        {
            Console.WriteLine("{0} has entered the protected area", Thread.CurrentThread.Name);

            //Simuating some work.
            Thread.Sleep(5000);

            Console.WriteLine("{0} is leaving the protected area", Thread.CurrentThread.Name);

            mut.ReleaseMutex();
            Console.WriteLine("{0} has released the mutex", Thread.CurrentThread.Name);

        }
        else
        {
            Console.WriteLine("{0} will not acquire the mutex", Thread.CurrentThread.Name);
        }
    }

    ~ExampleTwo()
    {
        mut.Dispose();
    }
}