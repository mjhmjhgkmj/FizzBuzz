public class FizzBuzz
{
    public static void Main(string[] args)
    {
        FizzBuzzProgram(Console.WriteLine, 350);
    }
    public static void FizzBuzzProgram(Action<string?> outputMethod, int n) =>
        outputMethod(Enumerable.Range(1, n)
            .Select(FizzBuzzPipeline)
            .Aggregate((a, b) => a + "\r\n" + b));

    static readonly Func<int, string?>[] handlers =
    [
        (n) => n % 3 == 0 ? "Три" : null,
        (n) => n % 5 == 0 ? "Пять" : null,
        (n) => n % 7 == 0 ? "Семь" : null,
        (n) => n % 11 == 0 ? "Одиннадать" : null,
        (n) => n % 13 == 0 ? "Тринадцать" : null,
        (n) => n % 17 == 0 ? "Семьнадцать" : null
    ];
    public static string FizzBuzzPipeline(int i)
    {
        var result = String.Join("", handlers.Select(f => f(i)));
        return result != "" ? result : i.ToString();
    }


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
