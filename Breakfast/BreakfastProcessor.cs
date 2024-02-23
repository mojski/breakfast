namespace Breakfast;

internal sealed class BreakfastProcessor
{
    public async Task<string> BoilWaterAsync(CancellationToken cancellationToken = default)
    {
        AsciArt.DrawTeaPot(ConsoleColor.Yellow);
        await Task.Delay(4 * 1000, cancellationToken);

        return "Hot water";
    }

    public async Task MakeTeaAsync(string water, CancellationToken cancellationToken = default)
    {
        await Task.Delay(2 * 1000, cancellationToken);
        await Console.Out.WriteLineAsync("Tea is ready");
        AsciArt.DrawCupOfTea(ConsoleColor.Yellow);
    }

    public async Task MakeSandwichAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(3 * 1000, cancellationToken);
        AsciArt.DrawSandwich(ConsoleColor.Red);
        Console.WriteLine("sandwich is ready");
    }

    public async Task GetCookieAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(2 * 1000, cancellationToken);
        Console.WriteLine("Get two cookies");
        AsciArt.DrawCookies(ConsoleColor.Green);
    }

    public void PrepareTable()
    {
        Thread.Sleep(4 * 1000);
        AsciArt.Table();
    }
}
