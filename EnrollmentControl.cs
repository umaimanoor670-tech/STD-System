using System;
using System.Data;
using System.Windows.Forms;
using STD_SYSTEM.Business;
using STD_SYSTEM.Models;

namespace STD_SYSTEM
{
    public partial class EnrollmentControl : UserControl
    {
        EnrollmentBAL bal = new EnrollmentBAL();

        public EnrollmentControl()
        {
            InitializeComponent();
        }

        private void EnrollmentControl_Load(object sender, EventArgs e)
        {
            LoadAllEnrollments();
        }

        private void LoadAllEnrollments()
        {
            dataGridView1.DataSource = bal.GetAllEnrollments();
        }

        // SAVE
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Enrollment en = new Enrollment
                {
                    StudentName = txtStudentName.Text,
                    Course = txtCourse.Text,
                    EnrollDate = dateTimePicker1.Value
                };
                bal.SaveEnrollment(en);
                MessageBox.Show("Enrollment saved successfully!");
                ClearFields();
                LoadAllEnrollments();
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
                Enrollment en = new Enrollment
                {
                    EID = int.Parse(txtEID.Text),
                    StudentName = txtStudentName.Text,
                    Course = txtCourse.Text,
                    EnrollDate = dateTimePicker1.Value
                };
                bal.UpdateEnrollment(en);
                MessageBox.Show("Enrollment updated successfully!");
                LoadAllEnrollments();
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
                int eid = int.Parse(txtEID.Text);
                bal.DeleteEnrollment(eid);
                MessageBox.Show("Enrollment deleted successfully!");
                ClearFields();
                LoadAllEnrollments();
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
                int eid = int.Parse(txtEID.Text);
                DataTable dt = bal.SearchEnrollment(eid);
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
            LoadAllEnrollments();
        }

        // Grid row click se textboxes fill hon
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtEID.Text = row.Cells["EID"].Value?.ToString();
                txtStudentName.Text = row.Cells["StudentName"].Value?.ToString();
                txtCourse.Text = row.Cells["Course"].Value?.ToString();
                if (row.Cells["EnrollDate"].Value != null)
                    dateTimePicker1.Value = Convert.ToDateTime(row.Cells["EnrollDate"].Value);
            }
        }

        private void ClearFields()
        {
            txtEID.Text = "";
            txtStudentName.Text = "";
            txtCourse.Text = "";
            dateTimePicker1.Value = DateTime.Today;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }
    }
}