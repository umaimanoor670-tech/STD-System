using System.Data;
using System.Data.SqlClient;
using STD_SYSTEM.Models;

namespace STD_SYSTEM.DataAccess
{
    public class StudentDAL
    {
        // ADD
        public void AddStudent(Student s)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Students (StudentName, StudentEmail, Phone) VALUES (@name, @email, @phone)", con);
                cmd.Parameters.AddWithValue("@name", s.StudentName);
                cmd.Parameters.AddWithValue("@email", s.StudentEmail);
                cmd.Parameters.AddWithValue("@phone", s.Phone);
                cmd.ExecuteNonQuery();
            }
        }

        // GET ALL
        public DataTable GetAllStudents()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // UPDATE
        public void UpdateStudent(Student s)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Students SET StudentName=@name, StudentEmail=@email, Phone=@phone WHERE StudentID=@id", con);
                cmd.Parameters.AddWithValue("@id", s.StudentID);
                cmd.Parameters.AddWithValue("@name", s.StudentName);
                cmd.Parameters.AddWithValue("@email", s.StudentEmail);
                cmd.Parameters.AddWithValue("@phone", s.Phone);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteStudent(int studentID)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Students WHERE StudentID=@id", con);
                cmd.Parameters.AddWithValue("@id", studentID);
                cmd.ExecuteNonQuery();
            }
        }

        // SEARCH
        public DataTable SearchStudent(int studentID)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Students WHERE StudentID=@id", con);
                cmd.Parameters.AddWithValue("@id", studentID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}