using ThreadPoolApp;

Console.WriteLine("***** Using the Thread Pool *****\n");

static void PrintTheNumbers(object state)
{
    Printer task = (Printer)state;
    task.PrintNumbers();
}

Printer p = new Printer();

//WaitCallback can point to any method that accepts a parameter of type object.
//In our case, we created the method PrintTheNumbers above for this purpose.
WaitCallback workItem = new WaitCallback(PrintTheNumbers);

for(int x = 0; x < 10; x++)
{
    //QueueUserWorkItem accepts one WaitCallback as first parameter and an object as second parameter, 
    //this second parameters corresponds to the object passed as parameter to the WaitCallback function.
    //In our case, this object is the Printer class.
    ThreadPool.QueueUserWorkItem(workItem, p);
}

Console.WriteLine("All tasks queued");
Console.ReadLine();