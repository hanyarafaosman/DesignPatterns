using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DesignPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatternsController : ControllerBase
    {
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
        /// Get list of all available patterns
        /// </summary>
        [HttpGet]
        public IActionResult GetAllPatterns()
        {
            var patterns = new List<object>();
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
        /// Run the "before" (problem) demo for a pattern
        /// </summary>
        [HttpGet("{patternId}/before")]
        public IActionResult RunBefore(string patternId)
        {
            if (!PatternMap.TryGetValue(patternId.ToLower(), out var pattern))
                return NotFound(new { error = $"Pattern '{patternId}' not found" });

            using var capture = new ConsoleOutputCapture();
            try
            {
                pattern.Before();
                var output = capture.GetOutput();
                return Ok(new
                {
                    pattern = pattern.Name,
                    phase = "before",
                    description = "Problem demonstration (without pattern)",
                    output
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Run the "after" (solution) demo for a pattern
        /// </summary>
        [HttpGet("{patternId}/after")]
        public IActionResult RunAfter(string patternId)
        {
            if (!PatternMap.TryGetValue(patternId.ToLower(), out var pattern))
                return NotFound(new { error = $"Pattern '{patternId}' not found" });

            using var capture = new ConsoleOutputCapture();
            try
            {
                pattern.After();
                var output = capture.GetOutput();
                return Ok(new
                {
                    pattern = pattern.Name,
                    phase = "after",
                    description = "Solution demonstration (with pattern)",
                    output
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Compare before and after for a pattern
        /// </summary>
        [HttpGet("{patternId}/compare")]
        public IActionResult Compare(string patternId)
        {
            if (!PatternMap.TryGetValue(patternId.ToLower(), out var pattern))
                return NotFound(new { error = $"Pattern '{patternId}' not found" });

            try
            {
                string beforeOutput, afterOutput;

                using (var capture = new ConsoleOutputCapture())
                {
                    pattern.Before();
                    beforeOutput = capture.GetOutput();
                }

                using (var capture = new ConsoleOutputCapture())
                {
                    pattern.After();
                    afterOutput = capture.GetOutput();
                }

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
        /// Run all patterns (before and after)
        /// </summary>
        [HttpGet("all")]
        public IActionResult RunAll()
        {
            using var capture = new ConsoleOutputCapture();
            try
            {
                PatternsDemo.RunAll();
                var output = capture.GetOutput();
                return Ok(new
                {
                    message = "All patterns executed",
                    totalPatterns = PatternMap.Count,
                    output
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get patterns grouped by category
        /// </summary>
        [HttpGet("categories")]
        public IActionResult GetByCategory()
        {
            var grouped = new Dictionary<string, List<object>>();

            foreach (var kvp in PatternMap)
            {
                var category = kvp.Value.Category;
                if (!grouped.ContainsKey(category))
                    grouped[category] = new List<object>();

                grouped[category].Add(new
                {
                    id = kvp.Key,
                    name = kvp.Value.Name,
                    description = kvp.Value.Description
                });
            }

            return Ok(grouped);
        }
    }
}
