using System.Data;
using STD_SYSTEM.DataAccess;
using STD_SYSTEM.Models;

namespace STD_SYSTEM.Business
{
    public class CourseBAL
    {
        CourseDAL dal = new CourseDAL();

        public void SaveCourse(Course c)
        {
            dal.AddCourse(c);
        }

        public DataTable GetAllCourses()
        {
            return dal.GetAllCourses();
        }

        public void UpdateCourse(Course c)
        {
            dal.UpdateCourse(c);
        }

        public void DeleteCourse(int courseID)
        {
            dal.DeleteCourse(courseID);
        }

        public DataTable SearchCourse(int courseID)
        {
            return dal.SearchCourse(courseID);
        }
    }
}