# Breakfast

It is simply application that helps you understand asynchronous programming in .NET. It will expand from branch to branch, explaining more topics.

## Cancellation

There is cancellation token source and event reacting on ctrl + c. 

```csharp
var tokenSource = new CancellationTokenSource();
var cancellationToken = tokenSource.Token;

// ctrl + c
Console.CancelKeyPress += (_, eventArgs) =>
{
    eventArgs.Cancel = true;
    tokenSource.Cancel();
};
```

If you pass this cancellationToken to async method app will throw TaskCanceledException which is handled in catch block. 

```csharp
IBreakfast scenario;
scenario = new AsynchronousScenario();

// uncomment this line to see synchronous scenario result
//scenario = new SynchronousScenario();

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
```

In app we will use different breakfast scenarios showing different app behaviors and implementations. 