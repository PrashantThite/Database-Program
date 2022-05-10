using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Database_Project.DLA;
using Database_Project.Model;

namespace Database_Project
{
    public partial class Form1 : Form
    {
        ProductDLA prodDLA = new ProductDLA();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                prod.Id = Convert.ToInt32( txtId.Text);
                prod.Name = txtName.Text;
                prod.Price =Convert.ToInt32( txtPrice.Text);
             int res=prodDLA.SaveProduct(prod);
                
                if (res == 1)
                {
                    MessageBox.Show("inserted sucessfully");
                    txtId.Enabled = true;
                    txtId.Clear();
                    txtName.Clear();
                    txtPrice.Clear();
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
             Product prod=   prodDLA.GetProductById(Convert.ToInt32(txtId.Text));
                txtName.Text = prod.Name;
                txtPrice.Text = prod.Price.ToString();
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
                Product prod = new Product();
                prod.Id = Convert.ToInt32(txtId.Text);
                prod.Name = txtName.Text;
                prod.Price = Convert.ToInt32(txtPrice.Text);
                int res = prodDLA.UpdateProduct(prod);
                if (res == 1)
                {
                    MessageBox.Show("Updated sucessfully");
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

                int res = prodDLA.DeleteProduct(Convert.ToInt32(txtId.Text));
                if (res == 1)
                {
                    MessageBox.Show("Deleted sucessfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                int res = prodDLA.AddNewProduct();
                txtId.Text = res.ToString();
                
                    txtId.Enabled = false;
                    txtName.Clear();
                    txtPrice.Clear();               
                
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
                dataGridView1.DataSource = prodDLA.ShowAllProduct();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           txtId.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();


        }
    }
}
