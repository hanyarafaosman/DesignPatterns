namespace DesignPattern.Strategy
{
    /// <summary>
    /// Strategy interface: Defines a family of algorithms.
    /// All strategies must implement this common interface.
    /// 
    /// Key Concept:
    /// - Encapsulates algorithm behavior
    /// - Allows algorithms to be interchangeable
    /// - Context depends on interface, not concrete classes
    /// </summary>
    public interface IOperation 
    { 
        string Execute(string s); 
    }
    
    /// <summary>
    /// Concrete Strategy A: Uppercase transformation.
    /// 
    /// Benefits:
    /// ✅ Isolated in its own class (Single Responsibility)
    /// ✅ Easy to unit test independently
    /// ✅ Can have its own state/dependencies if needed
    /// </summary>
    public class UpperOp : IOperation 
    { 
        public string Execute(string s) => s.ToUpper(); 
    }
    
    /// <summary>
    /// Concrete Strategy B: Lowercase transformation.
    /// 
    /// Adding new strategies:
    /// - Just create a new class implementing IOperation
    /// - No need to modify existing code (Open/Closed Principle)
    /// - Example: public class ReverseOp : IOperation { ... }
    /// </summary>
    public class LowerOp : IOperation 
    { 
        public string Execute(string s) => s.ToLower(); 
    }

    /// <summary>
    /// Context class: Uses a strategy without knowing its concrete type.
    /// 
    /// Key Principles:
    /// 1. Composition over inheritance
    /// 2. Depends on abstraction (IOperation), not concrete classes
    /// 3. Algorithm can be set at construction or runtime
    /// 4. Context is now simpler - just delegates to strategy
    /// </summary>
    public class StrategyContext
    {
        // Strategy is injected via constructor (Dependency Injection)
        private readonly IOperation _operation;
        
        /// <summary>
        /// Constructor: Accepts any IOperation implementation.
        /// This is where we select the algorithm.
        /// </summary>
        public StrategyContext(IOperation operation) 
        { 
            _operation = operation; 
        }
        
        /// <summary>
        /// Delegates to the injected strategy.
        /// Context doesn't need to know which algorithm is used!
        /// </summary>
        public string Do(string s) => _operation.Execute(s);
    }

    /// <summary>
    /// Demonstrates the solution: Algorithms encapsulated in strategy classes.
    /// 
    /// Advantages:
    /// ✅ Open/Closed: Add new strategies without modifying existing code
    /// ✅ Single Responsibility: Each strategy does one thing
    /// ✅ Testable: Test strategies independently
    /// ✅ Flexible: Swap strategies at runtime
    /// ✅ Type-safe: Compile-time checking instead of string "A"/"B"
    /// 
    /// Use Cases:
    /// - Sorting algorithms (QuickSort, MergeSort, BubbleSort)
    /// - Compression (ZIP, RAR, 7Z)
    /// - Payment methods (CreditCard, PayPal, Bitcoin)
    /// - Validation rules (Email, Phone, Address)
    /// - Route planning (Car, Walk, PublicTransport)
    /// </summary>
    public static class StrategyAfter
    {
        public static void Demo()
        {
            // Create contexts with different strategies
            // Strategy is selected at construction time
            var ctxA = new StrategyContext(new UpperOp());  // Type-safe!
            var ctxB = new StrategyContext(new LowerOp());
            
            // Use the contexts - they behave differently based on strategy
            System.Console.WriteLine($"StrategyAfter A: {ctxA.Do("Hello")}");
            System.Console.WriteLine($"StrategyAfter B: {ctxB.Do("Hello")}");
            // Output: "HELLO" and "hello" - same as Before
            // But now: cleaner, extensible, testable, maintainable!
        }
    }
}
