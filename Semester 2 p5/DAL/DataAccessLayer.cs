using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace DAL
{
    public class DataAccessLayer
    {
        static string connString = "Data Source = localhost; Initial Catalog = Semester 2 prac5; Integrated Security = true;";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;
        DataTable dt;


        public DataTable GetLogin(string Email, string Password)
        {
            dbConn.Open();

            //string sql = "sp_GetLogin";
            dbComm = new SqlCommand("sp_GetLogin", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbComm.Parameters.AddWithValue("@Email", Email);
            dbComm.Parameters.AddWithValue("@Password", Password);

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public int HardDeleteUser(int UserID)
        {
            
            dbComm = new SqlCommand("sp_HardDeleteUser", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@UserID", UserID);


            if (dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }
            int x = dbComm.ExecuteNonQuery();
           
            return x;
        }
        public int UpdateUser(User U)
        {
            
            dbComm = new SqlCommand("sp_UpdateUser", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@RoleID", U.RoleID);
            dbComm.Parameters.AddWithValue("@Status", U.Status);

            if (dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }
            int x = dbComm.ExecuteNonQuery();

           
            return x;
        }
        public int InsertUser(User U)
        {
           

            dbComm = new SqlCommand("sp_InsertUser", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Name", U.Name);
            dbComm.Parameters.AddWithValue("@Surname", U.Surname);
            dbComm.Parameters.AddWithValue("@Email", U.Email);
            dbComm.Parameters.AddWithValue("@Password", U.Password);
            dbComm.Parameters.AddWithValue("@RoleID", U.RoleID);
            dbComm.Parameters.AddWithValue("@Status", U.Status);


            if (dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }
            int x = dbComm.ExecuteNonQuery();

          
            return x;
        }
        public DataTable GetUser()
        {
          

            dbComm = new SqlCommand("sp_GetUser", dbConn);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            if (dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }

            return dt;
        }
          public int InsertRole(User U)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertRole", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

           
            dbComm.Parameters.AddWithValue("@RoleDescription", U.RoleDescription);
            


            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;
        }
        public DataTable GetRole()
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_GetRole", dbConn);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public int InsertPhoto(User U)
        {
            dbComm = new SqlCommand("sp_InsertPhoto", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Name", U.Name);
            dbComm.Parameters.AddWithValue("@ContentType", U.ContentType);
            dbComm.Parameters.AddWithValue("@Date", U.Date);
            dbComm.Parameters.AddWithValue("@Title", U.Title);
            //dbComm.Parameters.AddWithValue("@UploadData", U.UploadData);
            dbComm.Parameters.AddWithValue("@UserID", U.UserID);
            dbComm.Parameters.AddWithValue("@CategoryID", U.CategoryID);
            dbComm.Parameters.AddWithValue("@Status", U.Status);
            //dbComm = new SqlCommand("Insert into tblPhoto(UploadData,Image)Values(@UploadData,@Image)", dbConn);
            //dbComm.Parameters.AddWithValue("@UploadData", U.UploadData);
            //MemoryStream memstr = new MemoryStream();
            //dbComm.Parameters.AddWithValue("Image", memstr.ToArray());

            if (dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }
            int x = dbComm.ExecuteNonQuery();

            
            return x;
        }
        public DataTable GetPhoto()
        {
            
            dbComm = new SqlCommand("sp_GetPhoto", dbConn);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            if (dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }
            int x = dbComm.ExecuteNonQuery();

            return dt;
        }
        public int UpdatePhoto(User U)
        {

            dbComm = new SqlCommand("sp_UpdatePhoto", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PhotoID", U.PhotoID);
            dbComm.Parameters.AddWithValue("@Status", U.Status);

            if (dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }
            int x = dbComm.ExecuteNonQuery();


            return x;
        }
        public int InsertCategory(User U)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertCategory", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@CategoryDescription", U.CategoryDescription);



            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;
        }
        public DataTable GetCategory()
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_GetCategory", dbConn);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
    }
}
