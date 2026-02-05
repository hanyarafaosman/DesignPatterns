namespace DesignPattern.Proxy.Before
{
    public class HeavyImage
    {
        private readonly string _filename;

        public HeavyImage(string filename)
        {
            _filename = filename;
            LoadFromDisk(); // Always loads immediately - expensive!
        }

        private void LoadFromDisk()
        {
            System.Console.WriteLine($"  Loading {_filename} from disk...");
        }

        public void Display() => System.Console.WriteLine($"  Displaying {_filename}");
    }

    public static class ProxyBefore
    {
        public static void Demo()
        {
            System.Console.WriteLine("ProxyBefore:");
            // Problem: image loads even if never displayed
            var img = new HeavyImage("photo.jpg");
            // img.Display(); // might not even be called
        }
    }
}
