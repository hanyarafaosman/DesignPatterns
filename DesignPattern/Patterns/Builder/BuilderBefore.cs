namespace DesignPattern.Builder.Before
{
    public class Pizza
    {
        public string Size { get; set; }
        public bool Cheese { get; set; }
        public bool Pepperoni { get; set; }
        public bool Olives { get; set; }
        public bool Mushrooms { get; set; }
    }

    public static class BuilderBefore
    {
        public static void Demo()
        {
            System.Console.WriteLine("BuilderBefore:");
            // Problem: many constructor parameters or awkward initialization
            var pizza1 = new Pizza
            {
                Size = "Large",
                Cheese = true,
                Pepperoni = true,
                Olives = false,
                Mushrooms = true
            };
            System.Console.WriteLine($"  Pizza: {pizza1.Size}, cheese={pizza1.Cheese}, pepperoni={pizza1.Pepperoni}");
            // Hard to read, error-prone with many properties
        }
    }
}
