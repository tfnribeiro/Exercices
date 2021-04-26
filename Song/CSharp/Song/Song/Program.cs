using System;
using System.Collections.Generic;

namespace Song
{
    public class Song
    {
        public string name { get;  }
        public Song NextSong { get; set; }

        public Song(string name)
        {
            this.name = name;
        }

        public bool IsRepeatingPlaylist()
        {
            HashSet<string> seenSongs = new HashSet<string>();
            Song currentSong = this;
            bool songSeen = false;
            while(!songSeen && currentSong.NextSong != null)
            {
                seenSongs.Add(currentSong.name);
                currentSong = currentSong.NextSong;
                if (seenSongs.Contains(currentSong.name))
                    songSeen = true;
            }
            return songSeen;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Song first = new Song("Hello");
            Song second = new Song("Eye of the tiger");

            first.NextSong = second;
            second.NextSong = first;

            Console.WriteLine(first.IsRepeatingPlaylist());
            Song third = new Song("Hey Hey");
            Console.WriteLine(third.IsRepeatingPlaylist());
            Console.ReadKey();
        }
    }
}
