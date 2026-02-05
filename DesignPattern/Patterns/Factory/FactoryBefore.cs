namespace DesignPattern.Factory.Before
{
    public interface ITransport { string Move(); }
    public class Car : ITransport { public string Move() => "Driving a car"; }
    public class Bike : ITransport { public string Move() => "Riding a bike"; }

    public static class FactoryBefore
    {
        public static void Demo()
        {
            var car = new Car();
            var bike = new Bike();
            System.Console.WriteLine($"FactoryBefore: {car.Move()}, {bike.Move()}");
        }
    }
}
