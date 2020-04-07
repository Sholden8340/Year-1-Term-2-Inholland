using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program Top2000 = new Program();
            Top2000.Start();
        }

        void Start()
        {
            string filename = @"../../top2000-2019.csv";
            List<Song> songList = ReadSongs(filename);
            DisplaySongs(songList);

            List<string> doubleArtists = DoubleArtists(songList);

            Console.WriteLine("Double Artists");
            foreach (string s in doubleArtists)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();

        }

        Dictionary<string, List<Song>> DuplicateTitles(List<Song> songs)
        {
            Dictionary<string, List<Song>> duplicates = new Dictionary<string, List<Song>>();

            foreach (Song s in songs)
            {
                duplicates.Add(s.Title, s);
            }


        }

        List <Song> ReadSongs(string filename)
        {
            List<Song> songList = new List<Song>();
            StreamReader read = new StreamReader(filename);

            int count = 0;

            if (File.Exists(filename))
            {
                while(!read.EndOfStream)
                {
                    string[] song = read.ReadLine().Split(';');
                    songList.Add(new Song { 
                        Ranking = int.Parse(song[0]), 
                        Artist = song[2],
                        Title = song[1],
                        Year = int.Parse(song[3])
                    }); ;

                    count++;
                }
                
            }
            Console.WriteLine("Number of Read songs: {0}", count);
            read.Close();
            return songList;
        }

        void DisplaySongs(List<Song> songs)
        {
            foreach (Song s in songs)
            {
                Console.WriteLine("{0}. {1} - {2} ({3})", s.Ranking, s.Artist, s.Title, s.Year);
            }
        }

        List<string> DoubleArtists(List<Song> songs)
        {
            string last = songs[0].Artist;
            List<string> artists = new List<string>();

            foreach(Song s in songs)
            {
                if (s.Artist.Equals(last) && !artists.Contains(s.Artist))
                {
                    artists.Add(s.Artist);
                }
                else
                {
                    last = s.Artist;
                }
            }

            return artists;
        }
    }
}
