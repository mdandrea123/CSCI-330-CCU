using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CourseRegistration.Models;
using CourseRegistration.Services;

namespace CourseRegistration.Controllers
{
    [ApiController]
    // [Route("[controller]")]
    [Route("courses")]
    public class CoursesController : ControllerBase
    {

        private ICourseServices _courseServices;
        private static readonly List<Course> courses = new List<Course>();
        public CoursesController(ICourseServices courseServices)
        {
            // change to DI
            _courseServices = courseServices;
        }

        // Get All Courses
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            try
            {
                IEnumerable<Course> list = _courseServices.getCourses();
                if (courses.Count() == 0)
                {
                    foreach (Course c in list)
                    {
                        courses.Add(c);
                    }
                }

                if (courses != null) return Ok(courses);
                else return BadRequest();
                ;
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // Get Courses by Name
        [HttpGet("{name}", Name = "GetCourseByName")]
        public IActionResult GetCourseByName(string name)
        {
            IEnumerable<Course> list = _courseServices.getCourses();
            if (courses.Count() == 0)
            {
                foreach (Course c in list)
                {
                    courses.Add(c);
                }
            }

            foreach (Course c in courses)
            {
                if (c.Name.ToLower().Equals(name.ToLower()))
                {
                    return Ok(c);
                }
            }
            return NotFound();
        }

        // Get Courses by Department

        [HttpGet("search/")]
        public IActionResult GetCourseByDept(string dept)
        {
            IEnumerable<Course> list = _courseServices.getCourses();
            if (courses.Count() == 0)
            {
                foreach (Course c in list)
                {
                    courses.Add(c);
                }
            }

            foreach (Course c in courses)
            {
                if (c.Name.ToLower().Contains(dept.ToLower()))
                {
                    return Ok(c);
                }
            }
            return BadRequest();
        }

        // Add A New Course
        [HttpPost]
        public IActionResult CreateCourse(Course c)
        {
            IEnumerable<Course> list = _courseServices.getCourses();
            try
            {
                courses.Add(c);
                return CreatedAtRoute("GetCourseByName", new
                {
                    name = c.Name
                }, c);
            }
            catch (Exception e) { return StatusCode(500); }
        }

        // Update A Course
        [HttpPut("{name}")]
        public IActionResult UpdateCourse(string name, Course courseIn)
        {
            try
            {
                IEnumerable<Course> list = _courseServices.getCourses();
                if (courses.Count() == 0)
                {
                    foreach (Course c in list)
                    {
                        courses.Add(c);
                    }
                }

                foreach (Course c in courses)
                {
                    if (c.Name.ToLower().Equals(name.ToLower()))
                    {
                        c.Name = courseIn.Name;
                        c.Title = courseIn.Title;
                        c.Credits = courseIn.Credits;
                        c.Description = courseIn.Description;
                        return NoContent();
                    }
                }
                return BadRequest();
            }
            catch (Exception e) { return StatusCode(500); }
        }

        // Delete A Course
        [HttpDelete("{name}")]
        public IActionResult DeleteCourse(string name)
        {
            try
            {
                IEnumerable<Course> list = _courseServices.getCourses();
                if (courses.Count() == 0)
                {
                    foreach (Course c in list)
                    {
                        courses.Add(c);
                    }
                }

                foreach (Course c in courses)
                {
                    if (c.Name.ToLower().Equals(name.ToLower()))
                    {
                        courses.Remove(c);
                        return NoContent();
                    }
                }
                return BadRequest();
            }
            catch (Exception e) { return StatusCode(500); }
        }

        // Get all Core Goals of A Course
        [HttpGet("{name}/goals", Name = "GetCourseGoals")]

        public IActionResult GetCourseGoals(string name)
        {
            IEnumerable<CoreGoal> list = _courseServices.getGoalsByCourse(name);

            if (list != null) return Ok(list);
            else return BadRequest();
        }

        // Get all the offerings of a course in a semester
        [HttpGet("{name}/offerings/", Name = "GetCourseOfferings")]
        public IActionResult GetCourseOfferingsBySemester(string name, string semester)
        {
            IEnumerable<CourseOffering> list = _courseServices.getCourseOfferingsBySemester(semester);
            List<CourseOffering> offerings = new List<CourseOffering>();
            foreach (CourseOffering c in list)
            {
                if (c.TheCourse.Name.ToLower().Equals(name.ToLower()))
                {
                    offerings.Add(c);
                }
            }

            if (offerings != null) return Ok(offerings);
            else return BadRequest();

        }
    }
}

