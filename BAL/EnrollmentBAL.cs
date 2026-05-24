using System.Data;
using STD_SYSTEM.DataAccess;
using STD_SYSTEM.Models;

namespace STD_SYSTEM.Business
{
    public class EnrollmentBAL
    {
        EnrollmentDAL dal = new EnrollmentDAL();

        public void SaveEnrollment(Enrollment e)
        {
            dal.AddEnrollment(e);
        }

        public DataTable GetAllEnrollments()
        {
            return dal.GetAllEnrollments();
        }

        public void UpdateEnrollment(Enrollment e)
        {
            dal.UpdateEnrollment(e);
        }

        public void DeleteEnrollment(int eid)
        {
            dal.DeleteEnrollment(eid);
        }

        public DataTable SearchEnrollment(int eid)
        {
            return dal.SearchEnrollment(eid);
        }
    }
}