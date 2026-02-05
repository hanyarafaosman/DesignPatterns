namespace DesignPattern.Decorator
{
    public abstract class Beverage
    {
        public abstract string Description { get; }
        public abstract double Cost();
    }

    public class SimpleCoffee : Beverage
    {
        public override string Description => "Coffee";
        public override double Cost() => 1.0;
    }

    public abstract class AddOnDecorator : Beverage
    {
        protected Beverage _beverage;
        protected AddOnDecorator(Beverage b) { _beverage = b; }
    }

    public class Milk : AddOnDecorator
    {
        public Milk(Beverage b) : base(b) { }
        public override string Description => _beverage.Description + ", milk";
        public override double Cost() => _beverage.Cost() + 0.5;
    }

    public class Sugar : AddOnDecorator
    {
        public Sugar(Beverage b) : base(b) { }
        public override string Description => _beverage.Description + ", sugar";
        public override double Cost() => _beverage.Cost() + 0.2;
    }

    public static class DecoratorAfter
    {
        public static void Demo()
        {
            Beverage b = new SimpleCoffee();
            b = new Milk(b);
            b = new Sugar(b);
            System.Console.WriteLine($"DecoratorAfter: {b.Description} costs {b.Cost()}");
        }
    }
}
