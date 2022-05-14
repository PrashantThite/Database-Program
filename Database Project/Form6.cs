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
    public partial class Form6 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder scb;
        DataSet ds;
        public Form6()
        {
            InitializeComponent();
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(constr);
        }
        public DataSet GetStud()
        {
            da = new SqlDataAdapter("select * from Student", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Student");
            return ds;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetStud();
                DataRow row = ds.Tables["Student"].NewRow();
                row["RollNo"] = txtRollNo.Text;
                row["Name"] = txtName.Text;
                row["Stream"] = txtStream.Text;
                row["Percentage"] = txtPercent.Text;
                ds.Tables["Student"].Rows.Add(row);
                int res = da.Update(ds.Tables["Student"]);
                if (res == 1)
                {
                    MessageBox.Show("Saved Sucessfully");
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
                ds = GetStud();
                DataRow row = ds.Tables["Student"].Rows.Find(Convert.ToInt32(txtRollNo.Text));
                if (row != null)
                {
                    row["Name"] = txtName.Text;
                    row["Stream"] = txtStream.Text;
                    row["Percentage"] = txtPercent.Text;
                    int res = da.Update(ds.Tables["Student"]);
                    if (res == 1)
                    {
                        MessageBox.Show("Update Sucessfully");
                    }
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
                ds = GetStud();
                DataRow row = ds.Tables["Student"].Rows.Find(Convert.ToInt32(txtRollNo.Text));
                if (row != null)
                {
                     txtName.Text= row["Name"].ToString();
                   txtStream.Text = row["Stream"].ToString();
                    txtPercent.Text = row["Percentage"].ToString();
                    int res = da.Update(ds.Tables["Student"]);
                    if (res == 1)
                    {
                        MessageBox.Show("Update Sucessfully");
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
            ds = GetStud();
            DataRow row = ds.Tables["Student"].Rows.Find(Convert.ToInt32(txtRollNo.Text));
            row.Delete();
            int res = da.Update(ds.Tables["Student"]);
            if(res==1)
            {
                MessageBox.Show("Deleted susessfully");
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            ds = GetStud();

            dataGridView1.DataSource = ds.Tables["Student"];
        }
    }
}
