using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class Form5 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder scb;
        DataSet ds;
        public Form5()
        {
            InitializeComponent();
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(constr);
        }
        public DataSet GetProd()
        {
            da = new SqlDataAdapter("select * from product", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "product");
            return ds;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetProd();
                DataRow row = ds.Tables["product"].NewRow();
                row["id"] = txtId.Text;
                row["name"] = txtName.Text;
                row["price"] = txtPrice.Text;
                ds.Tables["product"].Rows.Add(row);
                int res = da.Update(ds.Tables["product"]);
                if(res==1)
                {
                    MessageBox.Show("Saved sucessfully");
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
                ds = GetProd();
                DataRow row = ds.Tables["product"].Rows.Find(Convert.ToInt32(txtId.Text));
                if (row != null)
                {
                    row["name"] = txtName.Text;
                    row["price"] = txtPrice.Text;

                    int res = da.Update(ds.Tables["product"]);
                    if (res == 1)
                    {
                        MessageBox.Show("Updated sucessfully");
                    }
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

                ds = GetProd();
                DataRow row = ds.Tables["product"].Rows.Find(Convert.ToInt32(txtId.Text));
                if (row != null)
                {
                    row.Delete();
                    int res = da.Update(ds.Tables["product"]);
                    if (res ==1)
                    {
                        MessageBox.Show("Deleted succesfully");
                    }
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
                ds = GetProd();
                DataRow row = ds.Tables["product"].Rows.Find(Convert.ToInt32(txtId.Text));
                if (row != null)
                {
                    txtName.Text = row["name"].ToString();
                    txtPrice.Text = row["price"].ToString();

                }
                else
                {
                    MessageBox.Show("No record found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
