using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using UserModel;

namespace UserDalLibrary
{
    public class UserDal
    {
        SqlConnection conn;
        SqlCommand cmdUserPage, cmdGetUsers, cmdUpdate, cmdDelete;
        public UserDal()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connCarousel"].ConnectionString);
        }

    

        public bool CarouselSaveData(UserModelLibrary saveData)
        {
            bool carouselStatus = false;
            conn.Open();
            cmdUserPage = new SqlCommand("SpInsert", conn);

            cmdUserPage.Parameters.AddWithValue("@userName", saveData.userName);
            cmdUserPage.Parameters.AddWithValue("@email", saveData.email);
            cmdUserPage.CommandType = CommandType.StoredProcedure;


            if (cmdUserPage.ExecuteNonQuery() > 0)
            {
                return carouselStatus = true;
            }
            conn.Close();
            return carouselStatus;
        }
        public List<UserModelLibrary> GetUserPageData()
        {
            conn.Open();
            List<UserModelLibrary> getAll = new List<UserModelLibrary>();
            cmdGetUsers = new SqlCommand("spGetUsersData", conn);
            cmdGetUsers.CommandType = CommandType.StoredProcedure;
            UserModelLibrary GetUser;
            SqlDataReader dataReader = cmdGetUsers.ExecuteReader();
            try
            {
                while (dataReader.Read())
                {
                    GetUser = new UserModelLibrary();
                   GetUser.userId = Convert.ToInt32(dataReader[0].ToString());
                    GetUser.userName = dataReader[1].ToString();
                    GetUser.email = dataReader[2].ToString();
                    //GetUser.skipRows = Convert.ToInt32(dataReader[3].ToString());
                    getAll.Add(GetUser);


                }
            }
           catch( Exception Io)
            {
                Console.WriteLine("Exception");
            }


            conn.Close();
            return getAll;
        }
        public List<UserModelLibrary> GetUserForUpdatePage(int userId)
        {
            conn.Open();
            List<UserModelLibrary> getAll = new List<UserModelLibrary>();
            cmdGetUsers = new SqlCommand("spGetUsersData", conn);
            cmdGetUsers.CommandType = CommandType.StoredProcedure;
            UserModelLibrary GetUser;
            SqlDataReader dataReader = cmdGetUsers.ExecuteReader();
            try
            {
                while (dataReader.Read())
                {
                    GetUser = new UserModelLibrary();
                    GetUser.userName = dataReader[1].ToString();
                    GetUser.email = dataReader[2].ToString();
                    //GetUser.skipRows = Convert.ToInt32(dataReader[3].ToString());
                    getAll.Add(GetUser);


                }
            }
            catch (Exception Io)
            {
                Console.WriteLine("Exception");
            }


            conn.Close();
            return getAll;
        }
        public bool UserUpdate(int userId, UserModelLibrary data)
        {
           
            bool carouselStatus = false;
                conn.Open();
            try
            {
                cmdUpdate = new SqlCommand("spUpdate", conn);
                cmdUpdate.Parameters.Add("@userId", SqlDbType.Int);
                cmdUpdate.Parameters.Add("@userName", SqlDbType.NVarChar,200);
                cmdUpdate.Parameters.Add("@email", SqlDbType.NVarChar, 200);
                cmdUpdate.Parameters[0].Value = userId;
                cmdUpdate.Parameters[1].Value = data.userName;
                cmdUpdate.Parameters[2].Value = data.email;
                cmdUpdate.CommandType = CommandType.StoredProcedure;
                if (cmdUpdate.ExecuteNonQuery() > 0)
                {
                    return carouselStatus = true;
                }
            }
               catch( Exception IO)
            {
                Console.WriteLine("update");
            }
            conn.Close();
            return carouselStatus;
        }

        public bool SoftDelete(int userId, int isDeleted)
        {
            bool carouselStatus = false;
            conn.Open();
            cmdDelete = new SqlCommand("softDelete", conn);
            cmdDelete.Parameters.AddWithValue("@userId", userId);
            cmdDelete.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmdDelete.CommandType = CommandType.StoredProcedure;
            if (cmdDelete.ExecuteNonQuery() > 0)
            {
                return carouselStatus = true;
            }
            conn.Close();
            return carouselStatus;
        }




    }
}
