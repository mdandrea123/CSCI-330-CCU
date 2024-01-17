using System;
using System.Collections.Generic;

namespace TV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Show one = new Show()
            {
                Name = "Parks and Recreation",
                NumEpisodes = 125,
                Year = 2009,
                Actors = new List<string>() {
                    "Amy Poehler",
                    "Aziz Ansari",
                    "Nick Offerman"
                }
            };

            Show two = new Show()
            {
                Name = "Burn Notice",
                NumEpisodes = 111,
                Year = 2007,
                Actors = new List<string>() {
                    "Jeffery Donovan",
                    "Gabrielle Anwar",
                    "Bruce Campbell"
                }
            };

            Show three = new Show()
            {
                Name = "Space Force",
                NumEpisodes = 10,
                Year = 2020,
                Actors = new List<string>() {
                    "Steve Carell",
                    "Ben Schwartz",
                    "John Malkovich"
                }
            };

            List<Show> shows = new List<Show>()
            {
                one,
                two,
                three
            };

            foreach (Show show in shows)
            {
                Console.WriteLine(show);
            }
            //Console.WriteLine(one);
            Console.WriteLine("---------------");
            shows.Sort();
            foreach (Show show in shows)
            {
                Console.WriteLine(show);
            }

            shows.Sort(new NumEpisodesComparer());
            Console.WriteLine("---------------");
            foreach (Show show in shows)
            {
                Console.WriteLine(show);
            }
        }
        

    }

    public class NumEpisodesComparer : IComparer<Show>
    {
        public int Compare(Show x, Show y)
        {
            return x.NumEpisodes - y.NumEpisodes;
        }
    }
}
