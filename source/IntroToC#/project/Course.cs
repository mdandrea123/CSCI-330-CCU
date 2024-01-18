using System;
using System.Collections.Generic;
using System.Text;

namespace project
{
    public class Course : IComparable<Course>, ICreditable
    {
        public string Name {get; set;}
        public string Title {get; set;}
        public int Credits {get; set;}
        public string Description {get; set;}

        public override string ToString()
        {
            return $"{Name} - {Title} - {Credits} credits";
        }

        public int CompareTo(Course other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
