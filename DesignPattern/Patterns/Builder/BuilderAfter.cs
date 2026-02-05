namespace DesignPattern.Builder.After
{
    public class Pizza
    {
        public string Size { get; set; } = "";
        public bool Cheese { get; set; }
        public bool Pepperoni { get; set; }
        public bool Olives { get; set; }
        public bool Mushrooms { get; set; }

        public override string ToString() => $"Pizza: {Size}, cheese={Cheese}, pepperoni={Pepperoni}";
    }

    public class PizzaBuilder
    {
        private readonly Pizza _pizza = new();

        public PizzaBuilder SetSize(string size) { _pizza.Size = size; return this; }
        public PizzaBuilder AddCheese() { _pizza.Cheese = true; return this; }
        public PizzaBuilder AddPepperoni() { _pizza.Pepperoni = true; return this; }
        public PizzaBuilder AddOlives() { _pizza.Olives = true; return this; }
        public PizzaBuilder AddMushrooms() { _pizza.Mushrooms = true; return this; }
        public Pizza Build() => _pizza;
    }

    public static class BuilderAfter
    {
        public static void Demo()
        {
            System.Console.WriteLine("BuilderAfter:");
            var pizza = new PizzaBuilder()
                .SetSize("Large")
                .AddCheese()
                .AddPepperoni()
                .AddMushrooms()
                .Build();
            System.Console.WriteLine($"  {pizza}");
        }
    }
}
