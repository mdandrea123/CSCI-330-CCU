using System;
using System.Collections.Generic;

namespace cs330_proj1
{
  public class CourseServices
  {
    // private CourseRepository repo = new CourseRepository();
    private readonly ICourseRepository _repo;

    public CourseServices(ICourseRepository courseRepo)
    {
      _repo = courseRepo;
    }


    //As a student, I want to search for course offerings that meet core goals
    // so that I can register easily for courses that meet my program requirements
    public List<CourseOffering> getOfferingsByGoalIdAndSemester(String theGoalId, String semester)
    {
      //finish this method during the tutorial
      //use the repo to get the data from the database (data store)
      List<CoreGoal> theGoals = _repo.Goals;
      List<CourseOffering> theOfferings = _repo.Offerings;

      //Complete any other required functionality/business logic to satisfy the requirement
      CoreGoal theGoal = null;
      foreach (CoreGoal cg in theGoals)
      {
        if (cg.Id.Equals(theGoalId))
        {
          theGoal = cg; break;

        }
      }
      if (theGoal == null) throw new Exception("Didn't find the goal");
      //search list of courses, then for each course, search offerings
      List<CourseOffering> courseOfferingsThatMeetGoal = new List<CourseOffering>();

      foreach (CourseOffering c in theOfferings)
      {
        if (c.Semester.Equals(semester)
           && theGoal.Courses.Contains(c.TheCourse))
        {
          courseOfferingsThatMeetGoal.Add(c);
        }

      }
      return courseOfferingsThatMeetGoal;
    }


    //Add more service functions here, as needed, for the project

    /* As a student, I want to see all available courses so that I know what my options are */
    public List<Course> getCourses()
    {
      List<Course> Courses = _repo.Courses;
      foreach (Course c in Courses)
      {
        // Console.WriteLine(c.Name);
      }

      List<Course> newCourses = new List<Course>();
      foreach (Course c in Courses)
      {
        // Console.WriteLine(c.Name);
        newCourses.Add(c);
      }

      return newCourses;
    }

    /* As a student, I want to see all course offerings by semester, so that I can choose from what's available to register for next semester */
    public List<CourseOffering> getCourseOfferingsBySemester(String semester)
    {
      // get all the courses that are available from the 'repo'
      List<CourseOffering> theOfferings = _repo.Offerings;

      // create a list stores the courses that are available for the given semester
      List<CourseOffering> offeringThisSemester = new List<CourseOffering>();

      // loop through all the courses that are available
      foreach (CourseOffering courseOffer in theOfferings)
      {
        // check if the course semester is the same as the given
        if (courseOffer.Semester.Equals(semester))
        {
          // if true, add it to courseOffer list
          offeringThisSemester.Add(courseOffer);
        }
      }

      // if there are no courses offered for the given semester, then log the sentence below.
      if (offeringThisSemester.Count == 0)
      {
        Console.WriteLine($"There are no courses available for {semester}.");
      }

      return offeringThisSemester;
    }

    /* As a student I want to see all course offerings by semester and department so that I can
    choose major courses to register for */
    public List<CourseOffering> getCourseOfferingsBySemesterAndDept(String semester, String department)
    {
      // get all courses that are available from the 'repo'
      List<CourseOffering> theOfferings = _repo.Offerings;

      // create a list that stores the list of courses that meets the requirement
      List<CourseOffering> courseOfferBySemesterAndDept = new List<CourseOffering>();
      // loop through all the courses
      foreach (CourseOffering course in theOfferings)
      {
        // check if the course is available for the given semester and the name contains the department name
        if (course.Semester.Equals(semester) && course.TheCourse.Name.Contains(department))
        {
          // if true, add the course to the list
          courseOfferBySemesterAndDept.Add(course);
        }
      }

      // check if there are any courses in the list, if not, log the following message
      if (courseOfferBySemesterAndDept.Count == 0)
      {
        Console.WriteLine($"There are no {department} courses offered in {semester}.");
      }

      return courseOfferBySemesterAndDept;
    }

    /* As a student I want to see all courses that meet a core goal, so that I can plan out
       my courses over the next few semesters and choose core courses that make sense for me */

    /* As a student I want to find a course that meets two different core goals, so that I can
    "feed two birds with one seed" (save time by taking one class that will fulfill two
      requirements */

    /* As a freshman adviser, I want to see all the core goals which do not have any course offerings
       for a given semester, so that I can work with departments to get some courses offered
       that students can take to meet those goals */


  }
}
