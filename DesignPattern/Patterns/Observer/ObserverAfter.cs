using System;

namespace DesignPattern.Observer
{
    public class StockPublisher
    {
        public event Action<decimal>? PriceChanged;
        private decimal _price;
        public decimal Price { get => _price; set { _price = value; PriceChanged?.Invoke(_price); } }
    }

    public static class ObserverAfter
    {
        public static void Demo()
        {
            var publisher = new StockPublisher();
            publisher.PriceChanged += p => System.Console.WriteLine($"ObserverAfter: notified price {p}");
            publisher.Price = 200;
            publisher.Price = 210;
        }
    }
}
