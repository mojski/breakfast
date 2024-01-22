namespace Breakfast;

public static class AsciArt
{
    public static void DrawTeaPot(ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;

        Console.WriteLine(
            $"{Environment.NewLine}            ;,'" +
            $"{Environment.NewLine}     _o_    ;:;'" +
            $"{Environment.NewLine} ,-.'---`.__ ;" +
            $"{Environment.NewLine}((j`=====',-'" +
            $"{Environment.NewLine} `-\\     /" +
            $"{Environment.NewLine}    `-=-'     hjw");

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void DrawCupOfTea(ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;

        Console.WriteLine(
            $"               )" +
            $"{Environment.NewLine}              (" +
            $"{Environment.NewLine}                )" +
            $"{Environment.NewLine}          ,.----------." +
            $"{Environment.NewLine}         ((|          |" +
            $"{Environment.NewLine}        .--\\          /--." +
            $"{Environment.NewLine}       '._  '========'  _.'" +
            $"{Environment.NewLine}  jgs     `\"\"\"\"\"\"\"\"\"\"\"\"`");

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void DrawSandwich(ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;

        Console.WriteLine($" _  __" +
            $"{Environment.NewLine}( `^` ))" +
            $"{Environment.NewLine}|     ||" +
            $"{Environment.NewLine}|     ||" +
            $"{Environment.NewLine}'-----'`");

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void DrawCokkies(ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;

        Console.WriteLine("          ___" +
                      $"{Environment.NewLine}       .'` __ `'.   ____" +
                      $"{Environment.NewLine}       |  '--'  |.'` __ `'. " +
                      $"{Environment.NewLine} jgs   \\`------`/|  '--'  |" +
                      $"{Environment.NewLine}        `------' \\`------`/" +
                      $"{Environment.NewLine}                  `------`");

        Console.ForegroundColor = ConsoleColor.White;
    }
}
