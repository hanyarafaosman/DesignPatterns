namespace DesignPattern.Factory.After
{
    public interface ITransport { string Move(); }
    public class Car : ITransport { public string Move() => "Driving a car"; }
    public class Bike : ITransport { public string Move() => "Riding a bike"; }

    public interface ITransportFactory { ITransport Create(); }
    public class CarFactory : ITransportFactory { public ITransport Create() => new Car(); }
    public class BikeFactory : ITransportFactory { public ITransport Create() => new Bike(); }

    public static class FactoryAfter
    {
        public static void Demo()
        {
            ITransportFactory factory = new CarFactory();
            var transport = factory.Create();
            System.Console.WriteLine($"FactoryAfter: {transport.Move()}");
        }
    }
}
