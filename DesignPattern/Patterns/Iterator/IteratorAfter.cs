using System.Collections;
using System.Collections.Generic;

namespace DesignPattern.Iterator.After
{
    public class Playlist : IEnumerable<string>
    {
        private readonly List<string> _songs = new() { "Song A", "Song B", "Song C" };

        // Internal structure hidden; provides iterator
        public IEnumerator<string> GetEnumerator() => _songs.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static class IteratorAfter
    {
        public static void Demo()
        {
            System.Console.WriteLine("IteratorAfter:");
            var playlist = new Playlist();
            // Client uses foreach - doesn't know about internal list
            foreach (var song in playlist)
            {
                System.Console.WriteLine($"  Playing: {song}");
            }
        }
    }
}
