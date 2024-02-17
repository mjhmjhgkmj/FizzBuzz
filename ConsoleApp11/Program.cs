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

    static int[] primes (int N) => 
        Enumerable.Range(2, N)
        .Where(IsPrime)
        .ToArray();

    public static bool IsPrime(int number) =>
        number >= 2 
        && Enumerable.Range(2, (int)Math.Sqrt(number) - 1)
           .All(i => number % i != 0);

    static Func<int, string?>[] handlers(int N) => primes(N).Select(prime =>
        new Func<int, string?>(n => n % prime == 0 ? prime.ToString() + "**" : null)
    ).ToArray();

    public static string FizzBuzzPipeline(int i)
    {
        var result = String.Join("", handlers(i).Select(f => f(i)));
        return result != "" ? result : i.ToString();
    }
    static object[][] mapper = [[3, "Три"], [5, "Пять"], [7, "Семь"]];
    public static string Do(int value) =>
        string.Join("", mapper
            .Where(item => value % (int)item[0] == 0)
            .Select(item => (string)item[1]));



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
