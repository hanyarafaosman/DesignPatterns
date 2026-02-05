namespace DesignPattern.Iterator.Before
{
    public class Playlist
    {
        private readonly string[] _songs = { "Song A", "Song B", "Song C" };

        // Exposes internal structure - clients depend on array
        public string[] GetSongs() => _songs;
    }

    public static class IteratorBefore
    {
        public static void Demo()
        {
            System.Console.WriteLine("IteratorBefore:");
            var playlist = new Playlist();
            // Problem: client must know about internal array structure
            var songs = playlist.GetSongs();
            for (int i = 0; i < songs.Length; i++)
            {
                System.Console.WriteLine($"  Playing: {songs[i]}");
            }
        }
    }
}
