# Breakfast 2. Breakfast Buddy

In this scenario, before we can seat to breakfast table, we need to prepare it by set plates and cutlery. Fortunately, your friend called and will eat breakfast with you and help you prepare it. We will give him a task so our previous work could be done uninterruptedly. Lets create task for our mate. 

Let's assume that setting the table is synchronous work and cannot be done "in the meantime". This means that one person would have to set the table first and then prepare breakfast. This synchronous locking operation will be simulated by the Thread.Sleep() method.

```csharp
public void PrepareTable()
{
    Thread.Sleep(4 * 1000);
    AsciArt.Table();
}
```
However, it would be great if this work could be done simultaneously. With the help of your friend. Therefore, we can create a second thread - representing two parallel processes.

Lets's create new scenario class called BreakfastForTwoScenario by copying AsynchronousScenario and modify MakeBreakfastMethod:

```csharp
public async Task MakeBreakfast(CancellationToken cancellationToken = default)
{
    var start = DateTime.UtcNow;

    processor.PrepareTable();
    
    // boil water, we will need it later
    var waterTask = processor.BoilWaterAsync(cancellationToken);

    // ... 
}
```

change Program.cs class to create BreakfastForTwoScenario implementation:
```csharp
IBreakfast scenario;
scenario = new BreakfastForTwoScenario();
```

After starting the program, making breakfast takes over 10 seconds (sum of PrepareTable and time taken by other methods). Because first the table was set and only then breakfast was prepared. Let's try to do both jobs with two people.


Asynchronous The equivalent of executing a synchronous method is creating a new thread and doing work on it.

```csharp
public async Task MakeBreakfast(CancellationToken cancellationToken = default)
{
    var start = DateTime.UtcNow;

    Thread preparationThread = new Thread( () => processor.PrepareTable())
    {
        IsBackground = false,
        Name = "Table preparation",
        Priority = ThreadPriority.Lowest
    };

    preparationThread.Start();

    // boil water, we will need it later
    var waterTask = processor.BoilWaterAsync(cancellationToken);
    // ...
}
```

We can change run preparation asynchronously and let the job (queuing task etc) for dotnet:

```csharp
public async Task MakeBreakfast(CancellationToken cancellationToken = default)
{
    var start = DateTime.UtcNow;

    var prepareTask = Task.Run(() => processor.PrepareTable(), cancellationToken);
    // other breakfast task
    //
   // 
    await prepareTask;

    // code
}
```

Task returns nothing, in theory we don't have to wait for it. if we remove await prepareTask the task will execute and you will see the plate in a console,
however, in the real world, by removing await, you lose the guarantee of work completion and may block the thread.

##  do and don'ts

- you should not run a large number of tasks at the same time in loop 
- be careful with creating multiple threads
- propagate cancellation tokens (pass it to called method like in this code)
- use asynchronous methods if available (ex. FirstOrDefaultAsync is bethe than FirstOrDefault)
- don't force asynchronicity, if a simple synchronous activity needs to be performed, more resources will be used to manage threads
- don't use async void unless you know what you're doing, 99% of the time return Task.

Read more about asynchronicity:

[Concurrency in C#](https://medium.com/@nirajranasinghe/understanding-concurrency-in-c-with-threads-tasks-and-threadpool-4c80f6e03df9)

[How To Use Task.Run in C# for Multithreading](https://www.bytehide.com/blog/task-run-csharp)

[Six ways to initiate tasks on another thread in .NET](https://markheath.net/post/starting-threads-in-dotnet)

[Async and Await in .NET 8 — Common Mistakes and Best Practices](https://admirlive.medium.com/async-and-await-in-net-8-common-mistakes-and-best-practices-a6b8016b62ee)

[Top 7 Common Async Mistakes](https://hamidmosalla.com/2018/04/21/top-7-common-async-mistakes/)

[Async/Await: Common Mistakes](https://dev.to/bhagatparwinder/async-await-common-mistakes-536)









