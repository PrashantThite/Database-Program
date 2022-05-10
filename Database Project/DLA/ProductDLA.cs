using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Database_Project.Model;

namespace Database_Project.DLA
{
    class ProductDLA
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDLA()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(constr);
        }

        public Product GetProductById(int id)
        {
            Product prod = new Product();
            string qry = "select * from product where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows) // existance of record in dr object
            {
                while (dr.Read())
                {
                    prod.Id = Convert.ToInt32(dr["Id"]);
                    prod.Name = dr["Name"].ToString();// ["Name"] should match col name

                    prod.Price = Convert.ToInt32(dr["Price"]);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("record not found");
            }
            con.Close();
            return prod;
        }
        public int SaveProduct(Product prod)
        {

            string qry = "insert into product values(@id,@name,@price)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", prod.Id);
            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int UpdateProduct(Product prod)
        {

            string qry = "update Product set Name=@name,Price=@price where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", prod.Id);
            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteProduct(int id)
        {
            string query = "delete from product where Id=@id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int AddNewProduct()
        {
            string query = "select max(Id)from product ";
            cmd = new SqlCommand(query, con);

            con.Open();
            object obj = cmd.ExecuteScalar();
            if (obj == DBNull.Value)
            {
                con.Close();
                return 1;
            }
            else
            {
                int id = Convert.ToInt32(obj);
                id++;
                con.Close();
                return id;
            }
            
        }

        public DataTable ShowAllProduct()
        {
            string query = "Select * from product";
            cmd = new SqlCommand(query, con);
            con.Open();
            dr = cmd.ExecuteReader();           
            
                DataTable table = new DataTable();
                table.Load(dr);

            return table;
        }
    }



}


