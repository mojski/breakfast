// See https://aka.ms/new-console-template for more information

using Breakfast.Scenarios;
using Breakfast;

var tokenSource = new CancellationTokenSource();
var cancellationToken = tokenSource.Token;

// ctrl + c
Console.CancelKeyPress += (_, eventArgs) =>
{
    eventArgs.Cancel = true;
    tokenSource.Cancel();
};

var processor = new BreakfastProcessor();
//var scenario = new SynchronousScenario(processor);

var scenario = new AsynchronousScenario(processor);

try
{
    await scenario.MakeBreakfast(cancellationToken);
}
catch (TaskCanceledException)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{Environment.NewLine} Breakfast caneled!!! {Environment.NewLine}");
    Console.ForegroundColor = ConsoleColor.White;
}
finally
{
    Console.WriteLine("End");
}    

Console.ReadKey();
