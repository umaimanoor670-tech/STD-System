using STD_SYSTEM.Business;
using STD_SYSTEM.Models;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace STD_SYSTEM
{
    public partial class STDControl1 : UserControl
    {
        StudentBAL bal = new StudentBAL();

        public STDControl1()
        {
            InitializeComponent();
        }

        private void StudentControl_Load(object sender, EventArgs e)
        {
            LoadAllStudents();
        }

        private void LoadAllStudents()
        {
            dataGridView1.DataSource = bal.GetAllStudents();
        }

        // SAVE
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Student s = new Student
                {
                    StudentName = txtName.Text,
                    StudentEmail = txtEmail.Text,
                    Phone = txtPhone.Text
                };
                bal.SaveStudent(s);
                MessageBox.Show("Student saved successfully!");
                ClearFields();
                LoadAllStudents();
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
                Student s = new Student
                {
                    StudentID = int.Parse(txtID.Text),
                    StudentName = txtName.Text,
                    StudentEmail = txtEmail.Text,
                    Phone = txtPhone.Text
                };
                bal.UpdateStudent(s);
                MessageBox.Show("Student updated successfully!");
                LoadAllStudents();
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
                int id = int.Parse(txtID.Text);
                bal.DeleteStudent(id);
                MessageBox.Show("Student deleted successfully!");
                ClearFields();
                LoadAllStudents();
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
                int id = int.Parse(txtID.Text);
                DataTable dt = bal.SearchStudent(id);
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
            LoadAllStudents();
        }

        // Grid row click se textboxes fill hon
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells["StudentID"].Value?.ToString();
                txtName.Text = row.Cells["StudentName"].Value?.ToString();
                txtEmail.Text = row.Cells["StudentEmail"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();
            }
        }

        private void ClearFields()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }
    }
}