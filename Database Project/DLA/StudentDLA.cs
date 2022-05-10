using Database_Project.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Project.DLA
{
    class StudentDLA
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public StudentDLA()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(constr);
        }

        public int Save(Student obj)
        {
            string qry = "insert into Student values(@RollNo,@name,@stream,@percent)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@RollNo", obj.RollNo);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@stream", obj.Stream);
            cmd.Parameters.AddWithValue("@percent", obj.Percentage);
            con.Open();
          int res=  cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int Update(Student obj)
        {
            string qry = "update  Student set Name=@name,Stream=@stream,Percentage=@percent where RollNo=@RollNo";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@RollNo", obj.RollNo);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@stream", obj.Stream);
            cmd.Parameters.AddWithValue("@percent", obj.Percentage);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int Delete(int rollno)
        {
            string qry= "delete from Student where RollNo = @RollNo";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@RollNo", rollno);
            con.Open();
           int res= cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public Student Search(int rollno)
        {
            Student stud = new Student();
            string qry = "select * from Student where RollNo=@RollNo";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@RollNo", rollno);
            con.Open();
            dr=cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    stud.Name = dr["Name"].ToString();
                    stud.Stream = dr["Stream"].ToString();
                    stud.Percentage = Convert.ToInt32(dr["Percentage"]);
                }
            }
            con.Close();
            return stud;
        }

        public DataTable ShowAll()
        {
            string qry = "select * from Student";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            con.Close();
            return table;
        }
    }
}
