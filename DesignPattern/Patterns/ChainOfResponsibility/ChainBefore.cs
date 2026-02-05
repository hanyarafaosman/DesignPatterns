namespace DesignPattern.ChainOfResponsibility.Before
{
    public class SupportRequest
    {
        public string Issue { get; set; } = "";
        public string Level { get; set; } = "";
    }

    public static class ChainBefore
    {
        public static void Demo()
        {
            System.Console.WriteLine("ChainBefore:");
            var request = new SupportRequest { Issue = "Critical bug", Level = "High" };

            // Problem: handler selection logic is centralized and rigid
            if (request.Level == "Low")
            {
                System.Console.WriteLine("  Junior support handles it");
            }
            else if (request.Level == "Medium")
            {
                System.Console.WriteLine("  Senior support handles it");
            }
            else if (request.Level == "High")
            {
                System.Console.WriteLine("  Manager handles it");
            }
        }
    }
}
