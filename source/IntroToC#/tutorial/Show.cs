using System;
using System.Collections.Generic;
using System.Text;

namespace TV
{
    public class Show : IComparable<Show>
    {
        public string Name {get; set;}
        public int Year {get; set;}
        public int NumEpisodes {get; set;}
        public List<string> Actors {get; set;}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("featuring ");
            foreach (string actor in Actors)
            {
                sb.Append(actor);
                sb.Append(", ");
            }
            string names = sb.Remove(sb.Length - 2, 2).ToString();
            return $"{Name} ({Year}) - {NumEpisodes} episodes, featuring {names}";
        }

        public int CompareTo(Show other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
