namespace Breakfast.Scenarios;

internal sealed class SynchronousScenario : IBreakfast
{
    private readonly BreakfastProcessor processor;
    public SynchronousScenario()
    {
        this.processor = new BreakfastProcessor();
    }

    public async Task MakeBreakfast(CancellationToken cancellationToken = default)
    {
        var start = DateTime.UtcNow;
        // boil water
        var water = await processor.BoilWaterAsync(cancellationToken);
        // make tea
        await processor.MakeTeaAsync(water, cancellationToken);
        // make sanwich
        await processor.MakeSandwichAsync(cancellationToken);
        // get cookies
        await processor.GetCookieAsync(cancellationToken);

        var now = DateTime.UtcNow;
        Console.WriteLine($"Breakfast is ready in {(now - start).TotalSeconds} seconds");

        Console.WriteLine("Like you can see there is no async in it. Even if all methods are async");
    }
}
