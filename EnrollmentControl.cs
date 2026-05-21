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

namespace STD_SYSTEM
{
    public partial class EnrollmentControl : UserControl
    {
        public EnrollmentControl()
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

                    SqlCommand cmd = new SqlCommand("INSERT INTO enrollments VALUES(@eid,@studentname,@course,@enrolldate)", con);

                    cmd.Parameters.AddWithValue("@EID", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@studentname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Course", textBox3.Text);
                    cmd.Parameters.AddWithValue("@EnrollDate", dateTimePicker1.Value);

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
            SqlCommand cmd = new SqlCommand("SELECT * FROM enrollments", con);

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

                    SqlCommand cmd = new SqlCommand("update enrollments set studentname=@studentname,course=@course,enrolldate=@enrolldate where eid=@eid", con);

                    cmd.Parameters.AddWithValue("@EID", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@studentname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Course", textBox3.Text);
                    cmd.Parameters.AddWithValue("@EnrollDate", dateTimePicker1.Value);

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
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("delete from enrollments where eid=@eid", con);

                    cmd.Parameters.AddWithValue("@EID", int.Parse(textBox1.Text));

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Record Deleted");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        { 
           dateTimePicker1.CustomFormat = "dd/MM/yyy";
        }

        private void EnrollmentControl_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM enrollments", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";

            }
        }
    }
    }
    
    


