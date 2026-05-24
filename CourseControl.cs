using System;
using System.Data;
using System.Windows.Forms;
using STD_SYSTEM.Business;
using STD_SYSTEM.Models;

namespace STD_SYSTEM
{
    public partial class CourseControl : UserControl
    {
        CourseBAL bal = new CourseBAL();

        public CourseControl()
        {
            InitializeComponent();
        }

        private void CourseControl_Load(object sender, EventArgs e)
        {
            LoadAllCourses();
        }

        private void LoadAllCourses()
        {
            dataGridView1.DataSource = bal.GetAllCourses();
        }

        // SAVE
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Course c = new Course
                {
                    CourseName = txtCourseName.Text,
                    Duration = txtDuration.Text
                };
                bal.SaveCourse(c);
                MessageBox.Show("Course saved successfully!");
                ClearFields();
                LoadAllCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // UPDATE
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Course c = new Course
                {
                    CourseID = int.Parse(txtCourseID.Text),
                    CourseName = txtCourseName.Text,
                    Duration = txtDuration.Text
                };
                bal.UpdateCourse(c);
                MessageBox.Show("Course updated successfully!");
                LoadAllCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // DELETE
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtCourseID.Text);
                bal.DeleteCourse(id);
                MessageBox.Show("Course deleted successfully!");
                ClearFields();
                LoadAllCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // SEARCH
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtCourseID.Text);
                DataTable dt = bal.SearchCourse(id);
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count == 0)
                    MessageBox.Show("No record found!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // LOAD ALL
        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            LoadAllCourses();
        }

        // Grid row click se textboxes fill hon
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtCourseID.Text = row.Cells["CourseID"].Value?.ToString();
                txtCourseName.Text = row.Cells["CourseName"].Value?.ToString();
                txtDuration.Text = row.Cells["Duration"].Value?.ToString();
            }
        }

        private void ClearFields()
        {
            txtCourseID.Text = "";
            txtCourseName.Text = "";
            txtDuration.Text = "";
        }
    }
}