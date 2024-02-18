public class FizzBuzz
{
    public static void Main(string[] args)
    {
        Console.WriteLine(FizzBuzzProgram(350));
    }
    public static string FizzBuzzProgram(int n) =>
        String.Join("\r\n", 
            Enumerable.Range(1, n).Select(FizzBuzzPipelineM));

    static readonly Func<int, string?>[] handlers = [(n) => n % 3 == 0 ? "Три" : null, (n) => n % 5 == 0 ? "Пять" : null];
    
    public static string FizzBuzzPipeline(int i) => Counter(i, String.Join("", handlers.Select(f => f(i))));

    public static string FizzBuzzPipelineM(int i)
    {
        var results = handlers.AsParallel().Select(handler => handler(i)).Where(r => r != null);
        return results.Any() ? string.Concat(results) : i.ToString();
    }

    private static string Counter(int i, string result) => result != "" ? result : i.ToString();

     static string Updater(int n)
    {
        string result = $"{(n % 3 == 0 ? "Fizz" : "")}{(n % 5 == 0 ? "Buzz" : "")}{(n % 7 == 0 ? "Qux" : "")}";
        return String.IsNullOrEmpty(result) ? n.ToString() : result;
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