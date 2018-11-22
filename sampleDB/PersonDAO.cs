using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace sampleDB
{
    public class PersonDAO
    {
        public static List<Person> getAllPerson()
        {
            List<Person> resultList = new List<Person>();
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
            string sqlStr = "SELECT * FROM Person";

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);
            //            da.SelectCommand.Parameters.AddWithValue("paraCustId", custId);
            // fill dataset
            da.Fill(ds, "resultTable");
            int rec_cnt = ds.Tables["resultTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach(DataRow row in ds.Tables["resultTable"].Rows)
                {
                    Person obj = new Person();   // create a customer instance
                    obj.PersonID = Convert.ToInt32(row["PersonID"]);
                    obj.FullName = row["FullName"].ToString();
                    obj.Gender = row["Gender"].ToString();
                    obj.PersonRole = row["PersonRole"].ToString();

                    resultList.Add(obj);

                }
            }

            return resultList;

        }
        public static Person getPersonById(int personID)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
            string sqlStr = "SELECT * FROM Person WHERE PersonID = @pPersonID";

            // change custId in where clause to custId1 or 
            // change connection string in web config to a wrong file name  

            Person obj = new Person();   // create a customer instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);
            da.SelectCommand.Parameters.AddWithValue("pPersonID", personID);
            // fill dataset
            da.Fill(ds, "resultTable");
            int rec_cnt = ds.Tables["resultTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["resultTable"].Rows[0];  // Sql command returns only one record
                obj.PersonID = Convert.ToInt32(row["PersonID"]);
                obj.FullName = row["FullName"].ToString();
                obj.Gender = row["Gender"].ToString();
                obj.PersonRole = row["PersonRole"].ToString();
            }
            else
            {
                obj = null;
            }

            return obj;
        }

        public static int updateById(int personID, string FullName, string Gender, string PersonRole)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE Person SET ");
            sqlStr.AppendLine("FullName = @pFullName,");
            sqlStr.AppendLine("Gender =@pGender,");
            sqlStr.AppendLine("PersonRole =@pPersonRole");
            sqlStr.AppendLine("WHERE PersonID = @pPersonID");



            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr.ToString(), myConn);
            cmd.Parameters.AddWithValue("pPersonID", personID);
            cmd.Parameters.AddWithValue("pFullName", FullName);
            cmd.Parameters.AddWithValue("pGender", Gender);
            cmd.Parameters.AddWithValue("pPersonRole", PersonRole);
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public static int deleteById(int personID)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            string sqlStr = "DELETE Person WHERE PersonID = @pPersonID";


     

            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, myConn);
            cmd.Parameters.AddWithValue("pPersonID", personID);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        public static int insert(string FullName, string Gender, string PersonRole)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            string sqlStr = 
                "INSERT INTO Person (FullName,Gender,PersonRole)VALUES(@pFullName,@pGender,@pPersonRole)";


            Person obj = new Person();   // create a customer instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, myConn);
            cmd.Parameters.AddWithValue("pFullName", FullName);
            cmd.Parameters.AddWithValue("pGender", Gender);
            cmd.Parameters.AddWithValue("pPersonRole", PersonRole);

            int result = cmd.ExecuteNonQuery();
            return result;
        }
    }
}