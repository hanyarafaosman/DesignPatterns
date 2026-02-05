namespace DesignPattern.State.After
{
    public interface IDocumentState
    {
        void Publish(Document doc);
        string Name { get; }
    }

    public class DraftState : IDocumentState
    {
        public string Name => "Draft";
        public void Publish(Document doc)
        {
            System.Console.WriteLine("  Document sent to moderation");
            doc.SetState(new ModerationState());
        }
    }

    public class ModerationState : IDocumentState
    {
        public string Name => "Moderation";
        public void Publish(Document doc)
        {
            System.Console.WriteLine("  Document published");
            doc.SetState(new PublishedState());
        }
    }

    public class PublishedState : IDocumentState
    {
        public string Name => "Published";
        public void Publish(Document doc) => System.Console.WriteLine("  Already published");
    }

    public class Document
    {
        private IDocumentState _state = new DraftState();
        public void SetState(IDocumentState state) => _state = state;
        public void Publish() => _state.Publish(this);
        public string CurrentState => _state.Name;
    }

    public static class StateAfter
    {
        public static void Demo()
        {
            System.Console.WriteLine("StateAfter:");
            var doc = new Document();
            System.Console.WriteLine($"  Initial: {doc.CurrentState}");
            doc.Publish();
            System.Console.WriteLine($"  After: {doc.CurrentState}");
        }
    }
}
