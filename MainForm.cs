using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STD_SYSTEM;


namespace STD_SYSTEM
{
    public partial class Form1 : Form
    {
        private string loggedInUser;
        public Form1(string username)
        {
            InitializeComponent();
            loggedInUser = username;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            STDControl1 st = new STDControl1();
            st.Dock = DockStyle.Fill;
            panelMain.Controls.Add(st);
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            CourseControl courseControl = new CourseControl();
            courseControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(courseControl);
        }

        private void btnEnrollment_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            EnrollmentControl enrollmentControl = new EnrollmentControl();
            enrollmentControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(enrollmentControl);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            panelMain.Controls.Clear();
            DashboardForm dashboardControl = new DashboardForm(loggedInUser);
            dashboardControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(dashboardControl);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LoadDashboard();
        }

   
    }
}
