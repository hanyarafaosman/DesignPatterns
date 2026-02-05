namespace DesignPattern.State.Before
{
    public class Document
    {
        public string CurrentState { get; set; } = "Draft";

        public void Publish()
        {
            // Problem: state transitions scattered in conditionals
            if (CurrentState == "Draft")
            {
                CurrentState = "Moderation";
                System.Console.WriteLine("  Document sent to moderation");
            }
            else if (CurrentState == "Moderation")
            {
                CurrentState = "Published";
                System.Console.WriteLine("  Document published");
            }
            else
            {
                System.Console.WriteLine("  Cannot publish from current state");
            }
        }
    }

    public static class StateBefore
    {
        public static void Demo()
        {
            System.Console.WriteLine("StateBefore:");
            var doc = new Document();
            System.Console.WriteLine($"  Initial: {doc.CurrentState}");
            doc.Publish();
            System.Console.WriteLine($"  After: {doc.CurrentState}");
        }
    }
}
