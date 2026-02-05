namespace DesignPattern.Strategy
{
    public class Context
    {
        public string Operation(string data, string algorithm)
        {
            if (algorithm == "A") return data.ToUpper();
            if (algorithm == "B") return data.ToLower();
            return data;
        }
    }

    public static class StrategyBefore
    {
        public static void Demo()
        {
            var ctx = new Context();
            System.Console.WriteLine($"StrategyBefore A: {ctx.Operation("Hello", "A")}");
            System.Console.WriteLine($"StrategyBefore B: {ctx.Operation("Hello", "B")}");
        }
    }
}
