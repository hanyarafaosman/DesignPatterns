namespace DesignPattern.Strategy
{
    public interface IOperation { string Execute(string s); }
    public class UpperOp : IOperation { public string Execute(string s) => s.ToUpper(); }
    public class LowerOp : IOperation { public string Execute(string s) => s.ToLower(); }

    public class StrategyContext
    {
        private readonly IOperation _operation;
        public StrategyContext(IOperation operation) { _operation = operation; }
        public string Do(string s) => _operation.Execute(s);
    }

    public static class StrategyAfter
    {
        public static void Demo()
        {
            var ctxA = new StrategyContext(new UpperOp());
            var ctxB = new StrategyContext(new LowerOp());
            System.Console.WriteLine($"StrategyAfter A: {ctxA.Do("Hello")}");
            System.Console.WriteLine($"StrategyAfter B: {ctxB.Do("Hello")}");
        }
    }
}
