namespace DesignPattern.Proxy.After
{
    public interface IImage
    {
        void Display();
    }

    public class RealImage : IImage
    {
        private readonly string _filename;

        public RealImage(string filename)
        {
            _filename = filename;
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            System.Console.WriteLine($"  Loading {_filename} from disk...");
        }

        public void Display() => System.Console.WriteLine($"  Displaying {_filename}");
    }

    // Virtual proxy: defers loading until Display() is called
    public class ImageProxy : IImage
    {
        private readonly string _filename;
        private RealImage? _realImage;

        public ImageProxy(string filename) { _filename = filename; }

        public void Display()
        {
            _realImage ??= new RealImage(_filename);
            _realImage.Display();
        }
    }

    public static class ProxyAfter
    {
        public static void Demo()
        {
            System.Console.WriteLine("ProxyAfter:");
            IImage img = new ImageProxy("photo.jpg");
            // Image not loaded yet - lazy initialization
            System.Console.WriteLine("  (Image not loaded yet)");
            img.Display(); // Now it loads
        }
    }
}
