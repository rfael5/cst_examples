using AddWithThreads;


AutoResetEvent _waitHandle = new AutoResetEvent(false);

void Add(object data)
{
    if(data is AddParams ap)
    {
        Console.WriteLine("Currently on thread: {0}", Environment.CurrentManagedThreadId);

        Console.WriteLine("{0} + {1} = {2}", ap.a, ap.b, ap.a + ap.b);
    }
    Thread.Sleep(5);
    
    _waitHandle.Set();
}

Console.WriteLine("***** Adding With Thread *****");

Console.WriteLine("ID of thread in Main: {0}", Environment.CurrentManagedThreadId);

AddParams addParams = new AddParams(10, 20);

Thread t = new Thread(new ParameterizedThreadStart(Add));

t.Start(addParams);

_waitHandle.WaitOne();
Console.WriteLine("Other thread is done.");

Console.ReadLine();


