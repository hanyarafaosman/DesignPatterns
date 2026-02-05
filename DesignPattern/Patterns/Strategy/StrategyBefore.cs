namespace DesignPattern.Strategy
{
    /// <summary>
    /// Context class with hard-coded algorithm selection logic.
    /// This represents the PROBLEM that Strategy pattern solves.
    /// 
    /// Issues:
    /// ❌ Hard to add new algorithms (violates Open/Closed Principle)
    /// ❌ Complex conditional logic clutters the code
    /// ❌ Difficult to test individual algorithms in isolation
    /// ❌ Algorithm logic mixed with context logic
    /// </summary>
    public class Context
    {
        /// <summary>
        /// Operation with conditional logic to select algorithm.
        /// 
        /// Problems:
        /// 1. To add a new algorithm, must modify this method
        /// 2. All algorithms are in one place (low cohesion)
        /// 3. Cannot swap algorithms at runtime dynamically
        /// 4. Hard to unit test each algorithm separately
        /// </summary>
        public string Operation(string data, string algorithm)
        {
            // Rigid if/else structure - what if we need 10 algorithms?
            if (algorithm == "A") return data.ToUpper();
            if (algorithm == "B") return data.ToLower();
            return data;  // Default fallback
        }
    }

    /// <summary>
    /// Demonstrates the problem: Algorithm selection with conditional logic.
    /// 
    /// Pain Points:
    /// - Adding algorithm "C" requires modifying Context class
    /// - Cannot inject algorithms from outside
    /// - Testing requires testing entire Context, not individual algorithms
    /// - Violates Single Responsibility (Context does selection AND execution)
    /// </summary>
    public static class StrategyBefore
    {
        public static void Demo()
        {
            var ctx = new Context();
            
            // Have to pass algorithm identifier as string - error-prone
            System.Console.WriteLine($"StrategyBefore A: {ctx.Operation("Hello", "A")}");
            System.Console.WriteLine($"StrategyBefore B: {ctx.Operation("Hello", "B")}");
            // Output: "HELLO" and "hello"
            // What if we typo "A" as "a"? Runtime error!
        }
    }
}
