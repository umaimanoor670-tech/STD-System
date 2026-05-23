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
    public partial class LoginForm : Form
    {
        //CONSTRUCTOR OF LOGIN FORM
        public LoginForm()
        {
            InitializeComponent();
        }
        //LOGIN BUTTON CLICK EVENT
        private void btnLogin_Click(object sender, EventArgs e)
        {
           // SQL CONNECTION
          SqlConnection con = new SqlConnection( @"Data Source=DESKTOP-VOCMGLJ\SQLEXPRESS;Initial Catalog=STdb;Integrated Security=True;Encrypt=False");
            con.Open();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
           //SQL QUERY TO CHECK LOGIN CREDENTIALS
            SqlCommand cmd = new SqlCommand("SELECT Username, Password FROM logintab WHERE Username='" + txtUsername.Text + "'and Password='" + txtPassword.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //GET LOGGED IN USER NAME FROM DATABASE RESULT
                string loggedInUser = dt.Rows[0]["Username"].ToString();
                MessageBox.Show("Login Success");
                //OPEN MAINFORM AND PASS USERNAME
                Form1 mainForm = new Form1(username);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login Please check user name and password");
            }
            //CLOSE DATABASE CONNECTION
            con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
 