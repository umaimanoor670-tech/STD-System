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
    public partial class DashboardForm : UserControl
    {
        private string username;
        public DashboardForm(string user)
        {
            InitializeComponent();
            username = user; 
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome" + username;
            display1();
            display2();
            display3();

        }
        private void display1()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM students", con);
                Int32 count = Convert.ToInt32(comm.ExecuteScalar());
                if (count > 0)
                {
                    lblCount2.Text = Convert.ToString(count.ToString());
                }
                else
                {
                    lblCount2.Text = "0";
                }
                con.Close();

            }
        }


        private void display2()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM courses", con);
                Int32 count = Convert.ToInt32(comm.ExecuteScalar());
                if (count > 0)
                {
                    lblCount3.Text = Convert.ToString(count.ToString());
                }
                else
                {
                    lblCount3.Text = "0";
                }
                con.Close();
            }
        }


        private void display3()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM enrollments", con);
                Int32 count = Convert.ToInt32(comm.ExecuteScalar());
                if (count > 0)
                {
                    lblCount4.Text = Convert.ToString(count.ToString());
                }
                else
                {
                    lblCount4.Text = "0";
                }
                con.Close();
            }
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblCount3_Click(object sender, EventArgs e)
        {

        }

        private void lblCount3_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
