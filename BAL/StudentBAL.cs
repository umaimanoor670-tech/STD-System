using System.Data;
using STD_SYSTEM.DataAccess;
using STD_SYSTEM.Models;

namespace STD_SYSTEM.Business
{
    public class StudentBAL
    {
        StudentDAL dal = new StudentDAL();

        public void SaveStudent(Student s)
        {
            dal.AddStudent(s);
        }

        public DataTable GetAllStudents()
        {
            return dal.GetAllStudents();
        }

        public void UpdateStudent(Student s)
        {
            dal.UpdateStudent(s);
        }

        public void DeleteStudent(int studentID)
        {
            dal.DeleteStudent(studentID);
        }

        public DataTable SearchStudent(int studentID)
        {
            return dal.SearchStudent(studentID);
        }
    }
}