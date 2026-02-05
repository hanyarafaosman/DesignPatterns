using System;
using System.Collections.Generic;

namespace DesignPattern
{
    public static class InteractiveMenu
    {
        private static readonly Dictionary<string, (string Name, Action Before, Action After)> Patterns = new()
        {
            { "1", ("Singleton", Singleton.SingletonBefore.Demo, Singleton.SingletonAfter.Demo) },
            { "2", ("Factory Method", Factory.Before.FactoryBefore.Demo, Factory.After.FactoryAfter.Demo) },
            { "3", ("Strategy", Strategy.StrategyBefore.Demo, Strategy.StrategyAfter.Demo) },
            { "4", ("Observer", Observer.ObserverBefore.Demo, Observer.ObserverAfter.Demo) },
            { "5", ("Decorator", Decorator.DecoratorBefore.Demo, Decorator.DecoratorAfter.Demo) },
            { "6", ("Adapter", Adapter.Before.AdapterBefore.Demo, Adapter.After.AdapterAfter.Demo) },
            { "7", ("Template Method", Template.Before.TemplateBefore.Demo, Template.After.TemplateAfter.Demo) },
            { "8", ("Command", Command.Before.CommandBefore.Demo, Command.After.CommandAfter.Demo) },
            { "9", ("Proxy", Proxy.Before.ProxyBefore.Demo, Proxy.After.ProxyAfter.Demo) },
            { "10", ("Iterator", Iterator.Before.IteratorBefore.Demo, Iterator.After.IteratorAfter.Demo) },
            { "11", ("Builder", Builder.Before.BuilderBefore.Demo, Builder.After.BuilderAfter.Demo) },
            { "12", ("Facade", Facade.Before.FacadeBefore.Demo, Facade.After.FacadeAfter.Demo) },
            { "13", ("State", State.Before.StateBefore.Demo, State.After.StateAfter.Demo) },
            { "14", ("Chain of Responsibility", ChainOfResponsibility.Before.ChainBefore.Demo, ChainOfResponsibility.After.ChainAfter.Demo) },
            { "15", ("Visitor", Visitor.Before.VisitorBefore.Demo, Visitor.After.VisitorAfter.Demo) }
        };

        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║         DESIGN PATTERNS INTERACTIVE DEMO                  ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");

                Console.WriteLine("Choose a pattern to explore:\n");

                Console.WriteLine("Creational Patterns:");
                Console.WriteLine("  1. Singleton          6. Adapter           11. Builder");
                Console.WriteLine("  2. Factory Method");
                Console.WriteLine("\nBehavioral Patterns:");
                Console.WriteLine("  3. Strategy           8. Command           13. State");
                Console.WriteLine("  4. Observer           10. Iterator         14. Chain of Responsibility");
                Console.WriteLine("  7. Template Method    15. Visitor");
                Console.WriteLine("\nStructural Patterns:");
                Console.WriteLine("  5. Decorator          9. Proxy             12. Facade");
                Console.WriteLine("\n  A. Run ALL patterns");
                Console.WriteLine("  Q. Quit\n");

                Console.Write("Your choice: ");
                var choice = Console.ReadLine()?.Trim().ToUpper();

                if (choice == "Q") break;
                if (choice == "A")
                {
                    Console.WriteLine("\nRunning all patterns...\n");
                    PatternsDemo.RunAll();
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                    continue;
                }

                if (Patterns.TryGetValue(choice ?? "", out var pattern))
                {
                    Console.WriteLine($"\n═══ {pattern.Name} Pattern ═══\n");
                    Console.WriteLine("BEFORE (Problem):");
                    pattern.Before();
                    Console.WriteLine("\nAFTER (Solution):");
                    pattern.After();
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Press any key to try again...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("\nThank you for exploring design patterns!");
        }
    }
}
