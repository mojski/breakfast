using Breakfast.Scenarios;

var tokenSource = new CancellationTokenSource();
var cancellationToken = tokenSource.Token;

// ctrl + c
Console.CancelKeyPress += (_, eventArgs) =>
{
    eventArgs.Cancel = true;
    tokenSource.Cancel();
};

IBreakfast scenario;
scenario = new BreakfastForTwoScenario();

// uncomment this line to see synchronous scenario result
//scenario = new SynchronousScenario();
//scenario = new AsynchronousScenario();
//var manuallyThreadScenario = new BreakfastForTwoScenario();
//await manuallyThreadScenario.MakeBreakFastWithManuallyCreatedThread(cancellationToken);

try
{
    await scenario.MakeBreakfast(cancellationToken);
}
catch (TaskCanceledException)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{Environment.NewLine} Breakfast canceled!!! {Environment.NewLine}");
    Console.ForegroundColor = ConsoleColor.White;
}
finally
{
    Console.WriteLine("End");
}

Console.ReadKey();
