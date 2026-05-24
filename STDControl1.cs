using STD_SYSTEM.Business;
using STD_SYSTEM.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace STD_SYSTEM
{
    public partial class STDControl1 : UserControl
    {
        StudentBAL bal = new StudentBAL();

        public STDControl1()
        {
            InitializeComponent();

            // Events binding
            this.Load += StudentControl_Load;

            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        // LOAD FORM
        private void StudentControl_Load(object sender, EventArgs e)
        {
            LoadAllStudents();
        }

        // LOAD ALL DATA
        private void LoadAllStudents()
        {
            try
            {
                dataGridView1.DataSource = bal.GetAllStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // SAVE
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Student s = new Student
                {
                    StudentID = int.Parse(txtID.Text),
                    StudentName = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
               
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
                if (!int.TryParse(txtID.Text, out int id))
                {
                    MessageBox.Show("Invalid Student ID");
                    return;
                }

                Student s = new Student
                {
                    StudentID = id,
                    StudentName = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim()
                };

                bal.UpdateStudent(s);

                MessageBox.Show("Student updated successfully!");

                ClearFields();
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
                if (!int.TryParse(txtID.Text, out int id))
                {
                    MessageBox.Show("Enter valid Student ID");
                    return;
                }

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
                if (!int.TryParse(txtID.Text, out int id))
                {
                    MessageBox.Show("Enter valid Student ID");
                    return;
                }

                DataTable dt = bal.SearchStudent(id);

                dataGridView1.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No record found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // LOAD ALL BUTTON
        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            LoadAllStudents();
        }

        // GRID CLICK FILL TEXTBOXES
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtID.Text = row.Cells["StudentID"]?.Value?.ToString();
                txtName.Text = row.Cells["StudentName"]?.Value?.ToString();
                txtEmail.Text = row.Cells["StudentEmail"]?.Value?.ToString();
                txtPhone.Text = row.Cells["Phone"]?.Value?.ToString();
            }
        }

        // CLEAR FIELDS
        private void ClearFields()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }
    }
}