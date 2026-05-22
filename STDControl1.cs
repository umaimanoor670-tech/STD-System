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

namespace STD_SYSTEM
{
    public partial class STDControl1 : UserControl
    {
        public STDControl1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void STDControl1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM students", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO students VALUES(@studentid,@studentname,@email,@phone)", con);

                    cmd.Parameters.AddWithValue("@studentid", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@studentname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox4.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Record Saved");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {





            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM students", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE students SET studentname=@studentname, email=@email, phone=@phone WHERE studentid=@studentid", con);

                    cmd.Parameters.AddWithValue("@studentid", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@studentname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox4.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Record Updated");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM students WHERE studentid=@studentid", con);

                    cmd.Parameters.AddWithValue("@studentid", int.Parse(textBox1.Text));

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Record Deleted");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM students WHERE studentid=@studentid", con);

                    cmd.Parameters.AddWithValue("@studentid", int.Parse(textBox1.Text));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // Optional: Fill textboxes with searched data
                    if (dt.Rows.Count > 0)
                    {
                        textBox2.Text = dt.Rows[0]["studentname"].ToString();
                        textBox3.Text = dt.Rows[0]["email"].ToString();
                        textBox4.Text = dt.Rows[0]["phone"].ToString();
                    }
                    else
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

    


