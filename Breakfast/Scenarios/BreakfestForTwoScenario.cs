namespace Breakfast.Scenarios;

internal class BreakfastForTwoScenario : IBreakfast
{
    private readonly BreakfastProcessor processor;
    public BreakfastForTwoScenario()
    {
        this.processor = new BreakfastProcessor();
    }

    public async Task MakeBreakfast(CancellationToken cancellationToken = default)
    {
        var start = DateTime.UtcNow;

        // create task and let thread management to runtime
        var prepareTask = CreateTaskFromFactory(cancellationToken);

        // boil water, we will need it later
        var waterTask = processor.BoilWaterAsync(cancellationToken);

        // time to make sandwich
        var sandwichTask =  processor.MakeSandwichAsync(cancellationToken);

        // get cookies
        var cookieTask =  processor.GetCookieAsync(cancellationToken);

        // now we need hot water to continue
        var water = await waterTask;
        var teaTask =  processor.MakeTeaAsync(water, cancellationToken);

        await prepareTask;
        // serve breakfast when all things are ready
        await Task.WhenAll(sandwichTask, cookieTask, teaTask);

        var now = DateTime.UtcNow;
        Console.WriteLine($"Breakfast is ready in {(now - start).TotalSeconds} seconds");
    }

    
    public async Task MakeBreakFastWithManuallyCreatedThread(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("MakeBreakFastWithManuallyCreatedThread scenario start");
        var start = DateTime.UtcNow;

        // run table preparation task
        CreateAndRunTaskManually();

        // boil water, we will need it later
        var waterTask = processor.BoilWaterAsync(cancellationToken);

        // time to make sandwich
        var sandwichTask =  processor.MakeSandwichAsync(cancellationToken);

        // get cookies
        var cookieTask =  processor.GetCookieAsync(cancellationToken);

        // now we need hot water to continue
        var water = await waterTask;
        var teaTask =  processor.MakeTeaAsync(water, cancellationToken);

        // serve breakfast when all things are ready
        await Task.WhenAll(sandwichTask, cookieTask, teaTask);

        var now = DateTime.UtcNow;
        Console.WriteLine($"Breakfast is ready in {(now - start).TotalSeconds} seconds");
    }

    private void CreateAndRunTaskManually()
    {
        var preparationThread = new Thread(() => processor.PrepareTable())
        {
            IsBackground = false,
            Name = "Table preparation",
            Priority = ThreadPriority.Lowest
        };

        preparationThread.Start();
    }

    private Task TaskRun(CancellationToken cancellationToken)
    {
        return Task.Run(() => processor.PrepareTable(), cancellationToken);
    }

    private Task CreateTaskFromFactory(CancellationToken cancellationToken)
    {
        return Task.Factory.StartNew(() => processor.PrepareTable(), cancellationToken);
    }
}