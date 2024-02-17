public class FizzBuzz
{
    public static void Main(string[] args)
    {
        FizzBuzzProgram(Console.WriteLine, 350);
    }
    public static void FizzBuzzProgram(Action<string?> outputMethod, int n) =>
        outputMethod(String.Join("\r\n", 
            Enumerable.Range(1, n).Select(FizzBuzzPipeline)));

    static readonly IEnumerable<Func<int, string?>> handlers = [(n) => n % 3 == 0 ? "Три" : null, (n) => n % 5 == 0 ? "Пять" : null];
    
    public static string FizzBuzzPipeline(int i) => Counter(i, String.Join("", handlers.Select(f => f(i))));
    
    private static string Counter(int i, string result) => result != "" ? result : i.ToString();

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