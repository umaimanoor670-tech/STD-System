using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STD_SYSTEM.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace STD_SYSTEM
{
    public partial class CourseControl : UserControl
    {
        //Constructor
        public CourseControl()
        {
            InitializeComponent();
        }
        //SAVE BUTTON

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Create SQL Connection
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    // Insert new record into Courses table

                    SqlCommand cmd = new SqlCommand("INSERT INTO Courses VALUES(@CourseID,@Course,@Duration)", con);

                    //Add parameter values from textboxes
                    cmd.Parameters.AddWithValue("@CourseID", txtCourseID.Text);
                    cmd.Parameters.AddWithValue("@Course", txtCourseName.Text);
                    cmd.Parameters.AddWithValue("@Duration", txtDuration.Text);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //LOAD DATA BUTTON

        private void button3_Click(object sender, EventArgs e)
        {
            //Create Connection
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False");
            con.Open();
            //Select all records
            SqlCommand cmd = new SqlCommand("SELECT * FROM courses", con);
            //Fill data table
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        //UPDATE BUTTON
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    //Update EXisting record

                    SqlCommand cmd = new SqlCommand("update courses set course=@course,duration=@duration where courseid=@courseid", con);

                    //Get updated values from textboxes
                    cmd.Parameters.AddWithValue("@Course", txtCourseName.Text);
                    cmd.Parameters.AddWithValue("@Duration", txtDuration.Text);
                    cmd.Parameters.AddWithValue("@courseid", int.Parse(txtCourseID.Text));

                    //Execute update query
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //DELETE BUTTON
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    //DELETE RECORD USING COURSEID

                    SqlCommand cmd = new SqlCommand("delete from courses where courseid=@courseid", con);
                    cmd.Parameters.AddWithValue("@CourseID", int.Parse(txtCourseID.Text));

                    //Execute delete query
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //FORM LOAD EVENT
        private void CourseControl_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False");

            con.Open();
            //RETRIEVE ALL COURSES RECORDS
            SqlCommand cmd = new SqlCommand("SELECT * FROM courses", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        //SEARCH BUTTON
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    //SEARCH RECORD BY COURSE ID
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM Courses WHERE CourseID=@CourseID", con);
                    //GET ID FROM TEXTBOX
                    cmd.Parameters.AddWithValue("@CourseID", int.Parse(txtCourseID.Text));
                    //FILL DATA TABLE WITH SEARCH 
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //DISPLAY RESULT
                    dataGridView1.DataSource = dt;
                    //SHOW MESSAGE IF NO RECORD FOUND
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Record Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}






