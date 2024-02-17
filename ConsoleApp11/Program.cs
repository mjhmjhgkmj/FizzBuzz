public class FizzBuzz
{
    public static void Main(string[] args)
    {
        FizzBuzzProgram2(Console.WriteLine, 35);
    }
    public static void FizzBuzzProgram(Action<string?> outputMethod, int n) =>
        outputMethod(Enumerable.Range(1, n)
            .Select(FizzBuzzPipeline)
            .Aggregate((a, b) => a + "\r\n" + b));

    static readonly Func<int, string?>[] handlers =
    [
        (n) => n % 3 == 0 ? "Fizz" : null,
        (n) => n % 5 == 0 ? "Buzz" : null,
        (n) => n % 7 == 0 ? "Quxx" : null
    ];
    static string? FizzBuzzPipeline(int i) =>
        handlers.Select(handler => handler(i))
                .Where(r => r != null)
                .DefaultIfEmpty(i.ToString())
                .Aggregate((a, b) => a + b);
    static void FizzBuzzProgram2(Action<string?> outputMethod, int n)
    {
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
                outputMethod("FizzBuzz");
            else if (i % 3 == 0)
                outputMethod("Fizz");
            else if (i % 5 == 0)
                outputMethod("Buzz");
            else
                outputMethod(i.ToString());
        }
    }
}
