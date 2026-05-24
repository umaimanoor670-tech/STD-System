using System.Data;
using System.Data.SqlClient;
using STD_SYSTEM.Models;

namespace STD_SYSTEM.DataAccess
{
    public class CourseDAL
    {
        // ADD
        public void AddCourse(Course c)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Courses (CourseName, Duration) VALUES (@name, @duration)", con);
                cmd.Parameters.AddWithValue("@name", c.CourseName);
                cmd.Parameters.AddWithValue("@duration", c.Duration);
                cmd.ExecuteNonQuery();
            }
        }

        // GET ALL
        public DataTable GetAllCourses()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Courses", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // UPDATE
        public void UpdateCourse(Course c)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Courses SET CourseName=@name, Duration=@duration WHERE CourseID=@id", con);
                cmd.Parameters.AddWithValue("@id", c.CourseID);
                cmd.Parameters.AddWithValue("@name", c.CourseName);
                cmd.Parameters.AddWithValue("@duration", c.Duration);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteCourse(int courseID)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Courses WHERE CourseID=@id", con);
                cmd.Parameters.AddWithValue("@id", courseID);
                cmd.ExecuteNonQuery();
            }
        }

        // SEARCH
        public DataTable SearchCourse(int courseID)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Courses WHERE CourseID=@id", con);
                cmd.Parameters.AddWithValue("@id", courseID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}