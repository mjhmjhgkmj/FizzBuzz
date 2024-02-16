public class FizzBuzz
{
    public static void Main(string[] args)
    {
        FizzBuzzProgram(Console.WriteLine, 35);
    }
    public static void FizzBuzzProgram(Action<string?> outputMethod, int n) =>
        outputMethod(Enumerable.Range(1, n)
            .Select(FizzBuzzPipeline)
            .Aggregate((a, b) => a + "\r\n" + b));

    static readonly List<Func<int, string?>> handlers =
    [
        (n) => n % 3 == 0 ? "Fizz" : null,
        (n) => n % 5 == 0 ? "Buzz" : null,
        (n) => n % 7 == 0 ? "Qux" : null
    ];
    static string? FizzBuzzPipeline(int i)=>
        handlers.Select(handler => handler(i))
                .Where(r => r != null)
                .DefaultIfEmpty(i.ToString())
                .Aggregate((a, b) => a + b);
}
