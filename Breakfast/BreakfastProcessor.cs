namespace Breakfast
{
    internal sealed class BreakfastProcessor
    {
        public async Task<string> BoilWaterAsync(CancellationToken cancellationToken = default)
        {
            Console.Write("Making tea...");
            AsciArt.DrawTeaPot(ConsoleColor.Yellow);
            await Task.Delay(4*1000, cancellationToken);

            return "Hot water";
        }

        public async Task MakeTeaAsync(string water, CancellationToken cancellationToken = default)
        {
            Console.Write($"I have {water} i can make tea");
            await Task.Delay(2*1000, cancellationToken);
            Console.Out.WriteLine("Tea is ready");
            AsciArt.DrawCupOfTea(ConsoleColor.Yellow);
        }

        public async Task MakeSandwichAsync(CancellationToken cancellationToken = default)
        {
            Console.WriteLine("Preparing sandwich ...");
            await Task.Delay(3*1000, cancellationToken);
            AsciArt.DrawSandwich(ConsoleColor.Red);
            Console.WriteLine("sandwich is ready");
        }

        public async Task GetCookieAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(2*1000, cancellationToken);
            Console.WriteLine("Get two cookies");
            AsciArt.DrawCokkies(ConsoleColor.Green);
        }
    }
}
