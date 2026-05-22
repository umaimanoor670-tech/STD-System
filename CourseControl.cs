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
        public CourseControl()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Courses VALUES(@CourseID,@Course,@Duration)", con);
                    cmd.Parameters.AddWithValue("@CourseID", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@Course", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Duration", textBox3.Text);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM courses", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("update courses set course=@course,duration=@duration where courseid=@courseid", con);
                    cmd.Parameters.AddWithValue("@CourseID", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@Course", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Duration", textBox3.Text);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
              using (SqlConnection  con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("delete from courses where courseid=@courseid", con);
                    cmd.Parameters.AddWithValue("@CourseID", int.Parse(textBox1.Text));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void CourseControl_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM courses", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        { 
            try
            {
                using (SqlConnection con = new SqlConnection( @"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM Courses WHERE CourseID=@CourseID", con);

                    cmd.Parameters.AddWithValue("@CourseID", int.Parse(textBox1.Text));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

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
    
    
    
    

            
