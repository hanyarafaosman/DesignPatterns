namespace DesignPattern.Decorator
{
    public class Coffee
    {
        public virtual string Description => "Plain coffee";
        public virtual double Cost() => 1.0;
    }

    public static class DecoratorBefore
    {
        public static void Demo()
        {
            var plain = new Coffee();
            System.Console.WriteLine($"DecoratorBefore: {plain.Description} costs {plain.Cost()}");
        }
    }
}
