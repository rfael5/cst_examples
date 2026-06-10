using System.Configuration.Assemblies;

CancellationTokenSource _cancelToken = new CancellationTokenSource();

do
{
    Console.WriteLine("Start any key to start processing");
    Console.ReadKey();
    Console.WriteLine("Processing");
    Task.Factory.StartNew(ProcessIntData);
    Console.WriteLine("Enter Q to quit: ");
    string answer = Console.ReadLine();
    if(answer.Equals("Q", StringComparison.OrdinalIgnoreCase))
    {
        _cancelToken.Cancel();
        break;
    }
}while(true);

Console.ReadLine();

void ProcessIntData()
{
    //Get a very large array of integers.
    int[] source = Enumerable.Range(1, 10_000_000).ToArray();

    //In parallel, find the numbers where num % 3 is true, returned in descending order.
    int[] modThreeIsZero = null;
    try
    {
        Thread.Sleep(3000);
        modThreeIsZero = (
            from num in source.AsParallel().WithCancellation(_cancelToken.Token)
            where num % 3 == 0
            orderby num descending
            select num
        ).ToArray();
        Console.WriteLine();
        Console.WriteLine($"Found {modThreeIsZero.Count()} numbers that match query!");
    }
    catch(OperationCanceledException ex)
    {
        Console.WriteLine(ex.Message);
    }
}