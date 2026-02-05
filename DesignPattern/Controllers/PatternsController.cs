using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DesignPattern.Controllers
{
    /// <summary>
    /// REST API Controller for exploring and testing design patterns.
    /// 
    /// Architecture:
    /// - Registry Pattern: PatternMap dictionary registers all available patterns with their demo methods
    /// - Output Capture: ConsoleOutputCapture redirects Console.WriteLine to capture demo output
    /// - Before/After Comparison: Each pattern has both problem (Before) and solution (After) demos
    /// 
    /// Endpoints:
    /// - GET /api/patterns → List all patterns with metadata
    /// - GET /api/patterns/{id}/before → Run problem demo (without pattern)
    /// - GET /api/patterns/{id}/after → Run solution demo (with pattern)
    /// - GET /api/patterns/{id}/compare → Side-by-side before/after comparison
    /// - GET /api/patterns/all → Execute all pattern demos
    /// - GET /api/patterns/categories → Group patterns by category (Creational/Structural/Behavioral)
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PatternsController : ControllerBase
    {
        /// <summary>
        /// Pattern Registry: Maps pattern IDs to their metadata and demo methods.
        /// 
        /// Structure: Dictionary<string, (Name, Before, After, Category, Description)>
        /// - Key: URL-friendly pattern ID (e.g., "singleton", "factory")
        /// - Value Tuple:
        ///   * Name: Display name (e.g., "Singleton", "Factory Method")
        ///   * Before: Action delegate for problem demo
        ///   * After: Action delegate for solution demo
        ///   * Category: Pattern type (Creational/Structural/Behavioral)
        ///   * Description: Brief explanation of what the pattern does
        /// 
        /// This registry pattern allows easy addition of new patterns without modifying endpoints.
        /// </summary>
        private static readonly Dictionary<string, (string Name, Action Before, Action After, string Category, string Description)> PatternMap = new()
        {
            { "singleton", ("Singleton", Singleton.SingletonBefore.Demo, Singleton.SingletonAfter.Demo, "Creational", "Ensures a class has only one instance") },
            { "factory", ("Factory Method", Factory.Before.FactoryBefore.Demo, Factory.After.FactoryAfter.Demo, "Creational", "Delegates object creation to factories") },
            { "strategy", ("Strategy", Strategy.StrategyBefore.Demo, Strategy.StrategyAfter.Demo, "Behavioral", "Encapsulates interchangeable algorithms") },
            { "observer", ("Observer", Observer.ObserverBefore.Demo, Observer.ObserverAfter.Demo, "Behavioral", "Notifies dependents of state changes") },
            { "decorator", ("Decorator", Decorator.DecoratorBefore.Demo, Decorator.DecoratorAfter.Demo, "Structural", "Adds responsibilities dynamically") },
            { "adapter", ("Adapter", Adapter.Before.AdapterBefore.Demo, Adapter.After.AdapterAfter.Demo, "Structural", "Converts one interface to another") },
            { "template", ("Template Method", Template.Before.TemplateBefore.Demo, Template.After.TemplateAfter.Demo, "Behavioral", "Defines algorithm skeleton") },
            { "command", ("Command", Command.Before.CommandBefore.Demo, Command.After.CommandAfter.Demo, "Behavioral", "Encapsulates requests as objects") },
            { "proxy", ("Proxy", Proxy.Before.ProxyBefore.Demo, Proxy.After.ProxyAfter.Demo, "Structural", "Controls access to another object") },
            { "iterator", ("Iterator", Iterator.Before.IteratorBefore.Demo, Iterator.After.IteratorAfter.Demo, "Behavioral", "Accesses elements sequentially") },
            { "builder", ("Builder", Builder.Before.BuilderBefore.Demo, Builder.After.BuilderAfter.Demo, "Creational", "Constructs complex objects step-by-step") },
            { "facade", ("Facade", Facade.Before.FacadeBefore.Demo, Facade.After.FacadeAfter.Demo, "Structural", "Simplifies complex subsystems") },
            { "state", ("State", State.Before.StateBefore.Demo, State.After.StateAfter.Demo, "Behavioral", "Changes behavior based on internal state") },
            { "chain", ("Chain of Responsibility", ChainOfResponsibility.Before.ChainBefore.Demo, ChainOfResponsibility.After.ChainAfter.Demo, "Behavioral", "Passes requests along handler chain") },
            { "visitor", ("Visitor", Visitor.Before.VisitorBefore.Demo, Visitor.After.VisitorAfter.Demo, "Behavioral", "Adds operations without modifying objects") }
        };

        /// <summary>
        /// Get list of all available patterns with metadata and endpoint URLs.
        /// 
        /// Returns:
        /// - count: Total number of patterns (15)
        /// - patterns: Array of pattern objects with:
        ///   * id: URL identifier (e.g., "singleton")
        ///   * name: Display name (e.g., "Singleton")
        ///   * category: Pattern type (Creational/Structural/Behavioral)
        ///   * description: Brief explanation
        ///   * endpoints: URLs for before/after/compare demos
        /// 
        /// Example: GET /api/patterns
        /// Use this as a discovery endpoint to see all available patterns.
        /// </summary>
        [HttpGet]
        public IActionResult GetAllPatterns()
        {
            var patterns = new List<object>();
            
            // Iterate through registry and build response with metadata
            foreach (var kvp in PatternMap)
            {
                patterns.Add(new
                {
                    id = kvp.Key,
                    name = kvp.Value.Name,
                    category = kvp.Value.Category,
                    description = kvp.Value.Description,
                    endpoints = new
                    {
                        before = $"/api/patterns/{kvp.Key}/before",
                        after = $"/api/patterns/{kvp.Key}/after",
                        compare = $"/api/patterns/{kvp.Key}/compare"
                    }
                });
            }

            return Ok(new { count = patterns.Count, patterns });
        }

        /// <summary>
        /// Run the "before" (problem) demo for a specific pattern.
        /// 
        /// This endpoint demonstrates the problem that the pattern solves.
        /// Shows code WITHOUT the pattern applied, highlighting issues like:
        /// - Tight coupling
        /// - Code duplication
        /// - Inflexibility
        /// - Poor separation of concerns
        /// 
        /// Example: GET /api/patterns/singleton/before
        /// Shows multiple instances causing inconsistent state.
        /// 
        /// Process:
        /// 1. Lookup pattern in registry by ID
        /// 2. Capture console output using ConsoleOutputCapture
        /// 3. Execute Before demo method
        /// 4. Return captured output as JSON response
        /// </summary>
        /// <param name="patternId">URL identifier (e.g., "singleton", "factory")</param>
        [HttpGet("{patternId}/before")]
        public IActionResult RunBefore(string patternId)
        {
            // Lookup pattern in registry (case-insensitive)
            if (!PatternMap.TryGetValue(patternId.ToLower(), out var pattern))
                return NotFound(new { error = $"Pattern '{patternId}' not found" });

            // Capture console output for API response
            using var capture = new ConsoleOutputCapture();
            try
            {
                // Execute the "Before" demo (problem)
                pattern.Before();
                var output = capture.GetOutput();
                
                return Ok(new
                {
                    pattern = pattern.Name,
                    phase = "before",
                    description = "Problem demonstration (without pattern)",
                    output  // Captured console output
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Run the "after" (solution) demo for a specific pattern.
        /// 
        /// This endpoint demonstrates the solution using the design pattern.
        /// Shows code WITH the pattern applied, highlighting improvements:
        /// - Loose coupling
        /// - DRY (Don't Repeat Yourself)
        /// - Flexibility and extensibility
        /// - Proper separation of concerns
        /// - Better maintainability
        /// 
        /// Example: GET /api/patterns/singleton/after
        /// Shows single instance ensuring consistent state.
        /// 
        /// Process:
        /// 1. Lookup pattern in registry by ID
        /// 2. Capture console output using ConsoleOutputCapture
        /// 3. Execute After demo method
        /// 4. Return captured output as JSON response
        /// </summary>
        /// <param name="patternId">URL identifier (e.g., "singleton", "factory")</param>
        [HttpGet("{patternId}/after")]
        public IActionResult RunAfter(string patternId)
        {
            // Lookup pattern in registry (case-insensitive)
            if (!PatternMap.TryGetValue(patternId.ToLower(), out var pattern))
                return NotFound(new { error = $"Pattern '{patternId}' not found" });

            // Capture console output for API response
            using var capture = new ConsoleOutputCapture();
            try
            {
                // Execute the "After" demo (solution)
                pattern.After();
                var output = capture.GetOutput();
                
                return Ok(new
                {
                    pattern = pattern.Name,
                    phase = "after",
                    description = "Solution demonstration (with pattern)",
                    output  // Captured console output
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Compare before and after implementations side-by-side.
        /// 
        /// This is the most useful endpoint for learning - it shows:
        /// - Problem: Output from Before demo (without pattern)
        /// - Solution: Output from After demo (with pattern)
        /// - Pattern metadata: Name, category, description
        /// 
        /// Allows direct comparison to understand the pattern's value.
        /// 
        /// Example: GET /api/patterns/strategy/compare
        /// Shows rigid if/else vs. flexible strategy classes.
        /// 
        /// Process:
        /// 1. Lookup pattern in registry
        /// 2. Run Before demo and capture output
        /// 3. Run After demo and capture output
        /// 4. Return both outputs with metadata for comparison
        /// </summary>
        /// <param name="patternId">URL identifier (e.g., "singleton", "factory")</param>
        [HttpGet("{patternId}/compare")]
        public IActionResult Compare(string patternId)
        {
            // Lookup pattern in registry (case-insensitive)
            if (!PatternMap.TryGetValue(patternId.ToLower(), out var pattern))
                return NotFound(new { error = $"Pattern '{patternId}' not found" });

            try
            {
                string beforeOutput, afterOutput;

                // Execute Before demo and capture output
                using (var capture = new ConsoleOutputCapture())
                {
                    pattern.Before();
                    beforeOutput = capture.GetOutput();
                }

                // Execute After demo and capture output
                using (var capture = new ConsoleOutputCapture())
                {
                    pattern.After();
                    afterOutput = capture.GetOutput();
                }

                // Return side-by-side comparison
                return Ok(new
                {
                    pattern = pattern.Name,
                    category = pattern.Category,
                    description = pattern.Description,
                    before = new { description = "Problem (without pattern)", output = beforeOutput },
                    after = new { description = "Solution (with pattern)", output = afterOutput }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Run all 15 patterns sequentially (both before and after demos).
        /// 
        /// This endpoint executes every pattern's Before and After demos in sequence,
        /// useful for:
        /// - Comprehensive testing
        /// - Generating complete demo output
        /// - Verifying all patterns work correctly
        /// - Educational presentations
        /// 
        /// Warning: Returns large output (all 30 demos).
        /// 
        /// Example: GET /api/patterns/all
        /// 
        /// Process:
        /// 1. Capture console output
        /// 2. Execute PatternsDemo.RunAll() which runs all Before/After demos
        /// 3. Return complete captured output
        /// </summary>
        [HttpGet("all")]
        public IActionResult RunAll()
        {
            // Capture all console output from all pattern demos
            using var capture = new ConsoleOutputCapture();
            try
            {
                // Execute all patterns (calls Before and After for each)
                PatternsDemo.RunAll();
                var output = capture.GetOutput();
                
                return Ok(new
                {
                    message = "All patterns executed",
                    totalPatterns = PatternMap.Count,
                    output  // Contains output from all 30 demos (15 patterns × 2)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get patterns grouped by their GoF (Gang of Four) category.
        /// 
        /// Returns patterns organized by:
        /// - Creational: Object creation mechanisms (Singleton, Factory, Builder)
        /// - Structural: Object composition (Adapter, Decorator, Facade, Proxy)
        /// - Behavioral: Object interaction patterns (Strategy, Observer, Command, etc.)
        /// 
        /// Useful for:
        /// - Understanding pattern taxonomy
        /// - Learning related patterns together
        /// - Navigating patterns by purpose
        /// 
        /// Example: GET /api/patterns/categories
        /// Returns:
        /// {
        ///   "Creational": [{id, name, description}, ...],
        ///   "Structural": [{id, name, description}, ...],
        ///   "Behavioral": [{id, name, description}, ...]
        /// }
        /// </summary>
        [HttpGet("categories")]
        public IActionResult GetByCategory()
        {
            // Dictionary to hold patterns grouped by category
            var grouped = new Dictionary<string, List<object>>();

            // Iterate through all patterns and group by category
            foreach (var kvp in PatternMap)
            {
                var category = kvp.Value.Category;
                
                // Initialize list for new category
                if (!grouped.ContainsKey(category))
                    grouped[category] = new List<object>();

                // Add pattern to its category group
                grouped[category].Add(new
                {
                    id = kvp.Key,
                    name = kvp.Value.Name,
                    description = kvp.Value.Description
                });
            }

            // Returns: { "Creational": [...], "Structural": [...], "Behavioral": [...] }
            return Ok(grouped);
        }
    }
}
