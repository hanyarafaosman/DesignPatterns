using System;

namespace DesignPattern
{
    public static class PatternsDemo
    {
        public static void RunAll()
        {
            Console.WriteLine("--- Design Patterns Demo ---\n");

            Singleton.SingletonBefore.Demo();
            Singleton.SingletonAfter.Demo();

            Factory.Before.FactoryBefore.Demo();
            Factory.After.FactoryAfter.Demo();

            Strategy.StrategyBefore.Demo();
            Strategy.StrategyAfter.Demo();

            Observer.ObserverBefore.Demo();
            Observer.ObserverAfter.Demo();

            Decorator.DecoratorBefore.Demo();
            Decorator.DecoratorAfter.Demo();

            Adapter.Before.AdapterBefore.Demo();
            Adapter.After.AdapterAfter.Demo();

            Template.Before.TemplateBefore.Demo();
            Template.After.TemplateAfter.Demo();

            Command.Before.CommandBefore.Demo();
            Command.After.CommandAfter.Demo();

            Proxy.Before.ProxyBefore.Demo();
            Proxy.After.ProxyAfter.Demo();

            Iterator.Before.IteratorBefore.Demo();
            Iterator.After.IteratorAfter.Demo();

            Builder.Before.BuilderBefore.Demo();
            Builder.After.BuilderAfter.Demo();

            Facade.Before.FacadeBefore.Demo();
            Facade.After.FacadeAfter.Demo();

            State.Before.StateBefore.Demo();
            State.After.StateAfter.Demo();

            ChainOfResponsibility.Before.ChainBefore.Demo();
            ChainOfResponsibility.After.ChainAfter.Demo();

            Visitor.Before.VisitorBefore.Demo();
            Visitor.After.VisitorAfter.Demo();
        }
    }
}
