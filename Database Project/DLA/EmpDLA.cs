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
    class EmpDLA
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public EmpDLA()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(constr);
        }

        public int Save(Emp e)
        {
            string qry = "insert into Employee values(@id,@name,@design,@salary)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", e.Eid);
            cmd.Parameters.AddWithValue("@name", e.Name);
            cmd.Parameters.AddWithValue("@design", e.Designation);
            cmd.Parameters.AddWithValue("@salary", e.Salary);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int Update(Emp e)
        {
            string qry = "update Employee set Designation=@design,Ename=@name,Salary=@salary where Eid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", e.Eid);
            cmd.Parameters.AddWithValue("@design", e.Designation);
            cmd.Parameters.AddWithValue("@name", e.Name);
            cmd.Parameters.AddWithValue("@salary", e.Salary);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int Delete(int id)
        {
            string query = "delete from Employee where Eid = @id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public Emp Search(int id)
        {
            string query = "select* from Employee where Eid = @id";
            cmd = new SqlCommand(query, con);
            Emp emp = new Emp();
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Name = dr["Ename"].ToString();
                    emp.Designation = dr["Designation"].ToString();
                    emp.Salary = Convert.ToInt32(dr["Salary"]);
                }
            }
            con.Close();
            return emp;
        }

        public DataTable ShowAll()
        {
            string querry = "select * from Employee";
            cmd = new SqlCommand(querry, con);
            con.Open();
           dr= cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            con.Close();
            return table;
        }
    }
}
