namespace Breakfast.Scenarios;

internal sealed class AsynchronousScenario : IBreakfast
{
    private readonly BreakfastProcessor processor;
    public AsynchronousScenario()
    {
        this.processor = new BreakfastProcessor();
    }

    public async Task MakeBreakfast(CancellationToken cancellationToken = default)
    {
        var start = DateTime.UtcNow;

        // boil water, we will need it later
        var waterTask = processor.BoilWaterAsync(cancellationToken);

        // time to make sandwich
        var sandwichTask =  processor.MakeSandwichAsync(cancellationToken);

        // get cookies
        var cookieTask =  processor.GetCookieAsync(cancellationToken);

        // now we need hot water to continue
        var water = await waterTask;
        var teaTask =  processor.MakeTeaAsync(water, cancellationToken);

        // serve breakfast when all thins are ready
        await Task.WhenAll(sandwichTask, cookieTask, teaTask);

        var now = DateTime.UtcNow;
        Console.WriteLine($"Breakfast is ready in {(now - start).TotalSeconds} seconds");
    }
}
