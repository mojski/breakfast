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

If we use async await like many programmers do, the only benefit will be the ability to cancel breakfast. Breakfast will be made synchronously step by step.

```csharp
// boil water
var water = await processor.BoilWaterAsync(cancellationToken);
// make tea
await processor.MakeTeaAsync(water, cancellationToken);
// make sandwich
await processor.MakeSandwichAsync(cancellationToken);
// get cookies
await processor.GetCookieAsync(cancellationToken);
```

But we don't have to waste our time to waiting for hot water. We can do sandwich and prepare cookies at the same time:

```csharp
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
```

