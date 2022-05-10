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
    public partial class Form2 : Form
    {
        EmpDLA empDLA = new EmpDLA();
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Emp emp = new Emp();
                emp.Eid = Convert.ToInt32(txtId.Text);
                emp.Name = txtName.Text;
                emp.Designation = txtDesign.Text;
                emp.Salary = Convert.ToInt32(txtSalary.Text);
                int res = empDLA.Save(emp);
                if (res == 1)
                {
                    MessageBox.Show("Save Sucessfully");
                    Clear();

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
                Emp emp = new Emp();
                emp.Eid = Convert.ToInt32(txtId.Text);
                emp.Name = txtName.Text;
                emp.Designation = txtDesign.Text;
                emp.Salary = Convert.ToInt32(txtSalary.Text);
              int res = empDLA.Update(emp);
                if(res==1)
                {
                    MessageBox.Show("Updated Sucessfully");
                    Clear();
                    
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
                Emp emp = new Emp();
                emp.Eid = Convert.ToInt32(txtId.Text);
                int res = empDLA.Delete(emp.Eid);
                if (res == 1)
                {
                    MessageBox.Show("Deleted Sucessfully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                Emp emp = new Emp();
              emp=  empDLA.Search(id);
                txtName.Text = emp.Name;
                txtDesign.Text = emp.Designation;
                txtSalary.Text = emp.Salary.ToString();

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
                dataGridView1.DataSource = empDLA.ShowAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Clear()
        {
            txtDesign.Clear();
            txtName.Clear();
            txtSalary.Clear();
        }
    }
}
