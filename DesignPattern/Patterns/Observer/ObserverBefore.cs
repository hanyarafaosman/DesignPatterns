namespace DesignPattern.Observer
{
    public class Stock
    {
        public decimal Price { get; set; }
    }

    public static class ObserverBefore
    {
        public static void Demo()
        {
            var stock = new Stock { Price = 100 };
            System.Console.WriteLine($"ObserverBefore: current price {stock.Price}");
            stock.Price = 110;
            System.Console.WriteLine($"ObserverBefore after change: current price {stock.Price}");
        }
    }
}
