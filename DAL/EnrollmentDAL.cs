using System;
using System.Data;
using System.Data.SqlClient;
using STD_SYSTEM.Models;

namespace STD_SYSTEM.DataAccess
{
    public class EnrollmentDAL
    {
        // ADD
        public void AddEnrollment(Enrollment e)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Enrollments (StudentName, Course, EnrollDate) VALUES (@studentname, @course, @enrolldate)", con);
                cmd.Parameters.AddWithValue("@studentname", e.StudentName);
                cmd.Parameters.AddWithValue("@course", e.Course);
                cmd.Parameters.AddWithValue("@enrolldate", e.EnrollDate);
                cmd.ExecuteNonQuery();
            }
        }

        // GET ALL
        public DataTable GetAllEnrollments()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Enrollments", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // UPDATE
        public void UpdateEnrollment(Enrollment e)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Enrollments SET StudentName=@studentname, Course=@course, EnrollDate=@enrolldate WHERE EID=@eid", con);
                cmd.Parameters.AddWithValue("@eid", e.EID);
                cmd.Parameters.AddWithValue("@studentname", e.StudentName);
                cmd.Parameters.AddWithValue("@course", e.Course);
                cmd.Parameters.AddWithValue("@enrolldate", e.EnrollDate);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteEnrollment(int eid)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Enrollments WHERE EID=@eid", con);
                cmd.Parameters.AddWithValue("@eid", eid);
                cmd.ExecuteNonQuery();
            }
        }

        // SEARCH
        public DataTable SearchEnrollment(int eid)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Enrollments WHERE EID=@eid", con);
                cmd.Parameters.AddWithValue("@eid", eid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}