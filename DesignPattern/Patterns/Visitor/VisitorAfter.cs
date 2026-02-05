namespace DesignPattern.Visitor.After
{
    public interface IShapeVisitor
    {
        void Visit(Circle circle);
        void Visit(Rectangle rectangle);
    }

    public interface IShape
    {
        void Accept(IShapeVisitor visitor);
    }

    public class Circle : IShape
    {
        public double Radius { get; set; } = 5;
        public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; } = 10;
        public double Height { get; set; } = 5;
        public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
    }

    public class AreaCalculator : IShapeVisitor
    {
        public double TotalArea { get; private set; }

        public void Visit(Circle circle)
        {
            double area = 3.14 * circle.Radius * circle.Radius;
            System.Console.WriteLine($"  Circle area: {area:F2}");
            TotalArea += area;
        }

        public void Visit(Rectangle rectangle)
        {
            double area = rectangle.Width * rectangle.Height;
            System.Console.WriteLine($"  Rectangle area: {area:F2}");
            TotalArea += area;
        }
    }

    public static class VisitorAfter
    {
        public static void Demo()
        {
            System.Console.WriteLine("VisitorAfter:");
            IShape[] shapes = { new Circle(), new Rectangle() };
            var calculator = new AreaCalculator();

            foreach (var shape in shapes)
                shape.Accept(calculator);
        }
    }
}
