using System.ComponentModel;

Console.WriteLine("Fun With Async ===>");
await MultipleAwaitWhenAnyAsync();
Console.WriteLine("Completed");
Console.ReadLine();

static string DoWork()
{
    Thread.Sleep(5_000);
    return "Done with work!";
}

static async Task TestAsynchronicity()
{
    string message = await DoWorkAsync();
    Console.WriteLine(message);
}

static async Task<string> DoWorkAsync()
{
    return await Task.Run(() =>
    {
        Thread.Sleep(5_000);
        return "Done with work!";
    });
}

static async Task MultipleAwaitsAsync()
{
    await Task.Run(() => {Thread.Sleep(3_000);});
    Console.WriteLine("Done with the first task!");

    await Task.Run(() => {Thread.Sleep(1_000);});
    Console.WriteLine("Done with the second task");

    await Task.Run(() => {Thread.Sleep(1_000);});
    Console.WriteLine("Done with the third task");
}

static async Task MultipleAwaitsInParallelAsync()
{
    await Task.WhenAll(
        Task.Run(() =>
        {
            Thread.Sleep(2_000);
            Console.WriteLine("Done with the first task!");
        }
        ),
        Task.Run(() =>
        {
            Thread.Sleep(1_000);
            Console.WriteLine("Done with the second task!");
        }
        ),
        Task.Run(() =>
        {
            Thread.Sleep(1_000);
            Console.WriteLine("Done with the third task!");
        }
        )
    );
}

static async Task MultipleAwaitWhenAnyAsync()
{
    await Task.WhenAny(
        Task.Run(() =>
        {
            Thread.Sleep(2_000);
            Console.WriteLine("Done with the first task!");
        }
        ),
        Task.Run(() =>
        {
            Thread.Sleep(3_000);
            Console.WriteLine("Done with the second task!");
        }
        ),
        Task.Run(() =>
        {
            Thread.Sleep(1_000);
            Console.WriteLine("Done with the third task!");
        }
        )

    );
}