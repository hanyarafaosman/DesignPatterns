namespace DesignPattern.ChainOfResponsibility.After
{
    public class SupportRequest
    {
        public string Issue { get; set; } = "";
        public string Level { get; set; } = "";
    }

    public abstract class SupportHandler
    {
        protected SupportHandler? _next;

        public void SetNext(SupportHandler handler) => _next = handler;

        public abstract void Handle(SupportRequest request);
    }

    public class JuniorSupport : SupportHandler
    {
        public override void Handle(SupportRequest request)
        {
            if (request.Level == "Low")
                System.Console.WriteLine("  Junior support handles it");
            else
                _next?.Handle(request);
        }
    }

    public class SeniorSupport : SupportHandler
    {
        public override void Handle(SupportRequest request)
        {
            if (request.Level == "Medium")
                System.Console.WriteLine("  Senior support handles it");
            else
                _next?.Handle(request);
        }
    }

    public class Manager : SupportHandler
    {
        public override void Handle(SupportRequest request)
        {
            System.Console.WriteLine("  Manager handles it");
        }
    }

    public static class ChainAfter
    {
        public static void Demo()
        {
            System.Console.WriteLine("ChainAfter:");
            var junior = new JuniorSupport();
            var senior = new SeniorSupport();
            var manager = new Manager();

            junior.SetNext(senior);
            senior.SetNext(manager);

            var request = new SupportRequest { Issue = "Critical bug", Level = "High" };
            junior.Handle(request);
        }
    }
}
