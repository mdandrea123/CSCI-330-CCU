using System;
using System.Collections.Generic;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            Course one = new Course()
            {
                Name = "CSCI 330",
                Title = "System Analysis/Software Engineering",
                Credits = 3.0,
                Description = "Welcome to CSCI 330 Systems Analysis and Software Engineering!"
            };

            Course two = new Course()
            {
                Name = "CSCI 390",
                Title = "Theory of Computation",
                Credits = 3.0,
                Description = "Welcome to CSCI 390 Theory of Computation!"
            };

            Course three = new Course()
            {
                Name = "CSCI 385",
                Title = "Intro to Information Security",
                Credits = 3.0,
                Description = "Welcome to CSCI 385 Intro to Information Security!"
            };

            Course four = new Course()
            {
                Name = "CSCI 401",
                Title = "Ethics & Professional Issues",
                Credits = 3.0,
                Description = "Welcome to CSCI 401 Ethics & Professional Issues!"
            };

            Course five = new Course()
            {
                Name = "STAT 201",
                Title = "Elementary Statistics",
                Credits = 4.0,
                Description = "Welcome to STAT 201 Elementary Statistics!"
            };

            Course six = new Course()
            {
                Name = "CSCI 356",
                Title = "Operating Systems",
                Credits = 3.0,
                Description = "Welcome to CSCI 356 Operating Systems!"
            };

            List<Course> courses = new List<Course>()
            {
                one,
                two,
                three,
                four,
                five,
                six
            };

            Console.WriteLine("Unsorted:");
            foreach (Course course in courses)
            {
                Console.WriteLine(course);
            }

            Console.WriteLine("\nSorted by Name:");
            courses.Sort();
            foreach (Course course in courses)
            {
                Console.WriteLine(course);
            }

            Console.WriteLine("\nSorted by Credits:");
            courses.Sort(new CreditComparer());
            foreach (Course course in courses)
            {
                Console.WriteLine(course);
            }
        }
    }
    public class CreditComparer : IComparer<Course>
    {
        public int Compare(Course x, Course y)
        {
            if (x.Credits > y.Credits)
            {
                return 1;
            }
            else if (x.Credits < y.Credits)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
