using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseRegistration.Models;
using CourseRegistration.Services;

namespace CourseRegistration.Services
{
  public interface ICourseServices
  {

    //As a student, I want to search for course offerings that meet core goals
    // so that I can register easily for courses that meet my program requirements
    public List<CourseOffering> getOfferingsByGoalIdAndSemester(String theGoalId, String semester);

    //Add more service functions here, as needed, for the project

    /* As a student, I want to see all available courses so that I know what my options are */
    public List<Course> getCourses();

    /* As a student, I want to see all course offerings by semester, so that I can choose from what's available to register for next semester */
    public List<CourseOffering> getCourseOfferingsBySemester(String semester);

    /* As a student I want to see all course offerings by semester and department so that I can
    choose major courses to register for */
    public List<CourseOffering> getCourseOfferingsBySemesterAndDept(String semester, String department);

    /* As a student I want to see all courses that meet a core goal, so that I can plan out
       my courses over the next few semesters and choose core courses that make sense for me */

    /* As a student I want to find a course that meets two different core goals, so that I can
    "feed two birds with one seed" (save time by taking one class that will fulfill two
      requirements */
    public List<CoreGoal> getGoalsByCourse(String name);

    /* As a freshman adviser, I want to see all the core goals which do not have any course offerings
       for a given semester, so that I can work with departments to get some courses offered
       that students can take to meet those goals */
  }
}
