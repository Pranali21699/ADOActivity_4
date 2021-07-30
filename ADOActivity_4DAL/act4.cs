using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADOActivity_4DAL
{
    public class act4
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public void StudentInfoDetails()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * from [myDatabase].[dbo].[StudentInfo]", sqlConObj);
            DataSet Ds = new DataSet();
            da.Fill(Ds);
            DataTable dt = Ds.Tables[0];//dataloaded in table

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"{dr["Name"]} : {dr["CompanyName"]}");
            }
            Console.WriteLine("reading complete");
            Ds = null;
        }

        public int updateName(int inroll, string inname, out int rowaf)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString());
            sqlCmdObj = new SqlCommand("dbo.GetStudent", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@RollNo", inroll);
            sqlCmdObj.Parameters.AddWithValue("@Name", inname);
            try
            {
                SqlParameter pr = sqlCmdObj.Parameters.Add("RetVal", SqlDbType.Int);
                pr.Direction = ParameterDirection.ReturnValue;
                da.SelectCommand = sqlCmdObj;
                da.Fill(dt);
                int returnValue = (int)pr.Value;
                rowaf = da.Update(dt);
                return returnValue;
            }

            catch (Exception )
            {
                Console.WriteLine("Error occured!");
                rowaf = 0;
                return 0;
            }

        }

        public int InsertName(int inroll, string inname,string inCompanyName,String inLocation, out int rowaf)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString());
            sqlCmdObj = new SqlCommand("dbo.GetStudent", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@RollNo", inroll);
            sqlCmdObj.Parameters.AddWithValue("@Name", inname);
            sqlCmdObj.Parameters.AddWithValue("@ComapanyName", inCompanyName);
            sqlCmdObj.Parameters.AddWithValue("@Location", inLocation);
            try
            {
                SqlParameter pr = sqlCmdObj.Parameters.Add("RetVal", SqlDbType.Int);
                pr.Direction = ParameterDirection.ReturnValue;
                da.SelectCommand = sqlCmdObj;
                da.Fill(dt);
                int returnValue = (int)pr.Value;
                rowaf = da.Update(dt);
                return returnValue;
            }

            catch (Exception )
            {
                Console.WriteLine("Error occured!");
                rowaf = 0;
                return 0;
            }

        }

        public int DeleteName(int inroll, out int rowaf)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString());
            sqlCmdObj = new SqlCommand("dbo.GetStudent", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@RollNo", inroll);
            
            try
            {
                SqlParameter pr = sqlCmdObj.Parameters.Add("RetVal", SqlDbType.Int);
                pr.Direction = ParameterDirection.ReturnValue;
                da.SelectCommand = sqlCmdObj;
                da.Fill(dt);
                int returnValue = (int)pr.Value;
                int check = sqlCmdObj.ExecuteNonQuery();

                rowaf = check;
                return returnValue;
            }

            catch (Exception )
            {
                Console.WriteLine("Error occured!");
                rowaf = 0;
                return 0;
            }

        }

        //Using stored procedure
        /*SqlCommand sqlCmdObj = new SqlCommand();
        sqlCmdObj = new SqlCommand("GetStudent", sqlConObj);
        sqlCmdObj.Parameters.Add(new SqlParameter("@RollNo", 3));
        sqlCmdObj.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter objDa = new SqlDataAdapter();
        objDa.SelectCommand = sqlCmdObj;

        DataSet objDs = new DataSet();
        objDa.Fill(objDs);
        DataTable objDt = objDs.Tables[0];

        Console.WriteLine("dataload complete.");

        foreach (DataRow dr in objDt.Rows)
        {
            Console.WriteLine($"{dr["Name"]} : {dr["CompanyName"]}");
        }
        Console.WriteLine("reading complete");*/

        //Update using stored procedure
        /* SqlDataAdapter objDa = new SqlDataAdapter("Select RollNo, Name, CompanyName, Loaction from [dbo].[StudentInfo]", sqlConObj);
         objDa.UpdateCommand = new SqlCommand("Update StudentInfo set Name=@Name where @RollNo= RollNo", sqlConObj);
         objDa.UpdateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
         SqlParameter parameter = objDa.UpdateCommand.Parameters.Add("@RollNo", SqlDbType.Int);
         parameter.SourceColumn = "RollNo";
         parameter.SourceVersion = DataRowVersion.Original;

         DataTable objDt = new DataTable();
         objDa.Fill(objDt);

         DataRow _row = objDt.Rows[0];
         _row["Name"] = "Panda";

         objDa.Update(objDt);
         Console.WriteLine("update complete.");

         foreach (DataRow dr in objDt.Rows)
         {
             Console.WriteLine($"{dr["RollNo"]} : {dr["Name"]}");
         }
         Console.WriteLine("reading complete");*/




    }
}
