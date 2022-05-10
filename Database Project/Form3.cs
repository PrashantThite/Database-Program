using Database_Project.DLA;
using Database_Project.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class Form3 : Form
    {
        StudentDLA studDla = new StudentDLA();
        public Form3()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = new Student();
                stud.RollNo = Convert.ToInt32(txtRollNo.Text);
                stud.Name = txtName.Text;
                stud.Stream = txtStream.Text;
                stud.Percentage = Convert.ToInt32(txtPercent.Text);
                int res = studDla.Save(stud);
                if (res == 1)
                {
                    MessageBox.Show("Saved");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = new Student();
                stud.RollNo = Convert.ToInt32(txtRollNo.Text);
                stud.Name = txtName.Text;
                stud.Stream = txtStream.Text;
                stud.Percentage = Convert.ToInt32(txtPercent.Text);
                int res = studDla.Update(stud);
                if (res == 1)
                {
                    MessageBox.Show("Update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int res =studDla.Delete( Convert.ToInt32(txtRollNo.Text));
                if (res == 1)
                {
                    MessageBox.Show("Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int res = Convert.ToInt32(txtRollNo.Text);
                Student stud = studDla.Search(res);
                
                    txtName.Text = stud.Name;
                    txtStream.Text = stud.Stream;
                    txtPercent.Text = stud.Percentage.ToString();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = studDla.ShowAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
