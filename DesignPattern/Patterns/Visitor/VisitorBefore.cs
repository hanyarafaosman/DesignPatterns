namespace DesignPattern.Visitor.Before
{
    public class Circle
    {
        public double Radius { get; set; } = 5;
    }

    public class Rectangle
    {
        public double Width { get; set; } = 10;
        public double Height { get; set; } = 5;
    }

    public static class VisitorBefore
    {
        public static void Demo()
        {
            System.Console.WriteLine("VisitorBefore:");
            // Problem: adding new operations requires modifying each class
            var circle = new Circle();
            var rect = new Rectangle();

            // Calculate area inline
            double circleArea = 3.14 * circle.Radius * circle.Radius;
            double rectArea = rect.Width * rect.Height;

            System.Console.WriteLine($"  Circle area: {circleArea:F2}");
            System.Console.WriteLine($"  Rectangle area: {rectArea:F2}");
        }
    }
}
