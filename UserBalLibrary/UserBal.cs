using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDalLibrary;
using UserModel;

namespace UserBalLibrary
{
    public class UserBal
    {
        UserDal dal;
        public UserBal()
        {
            dal = new UserDal();
        }
        public bool InsertSavePage(UserModelLibrary saveData)
        {

            return dal.CarouselSaveData(saveData);
        }
        public List<UserModelLibrary> GetUserData()
        {
            return dal.GetUserPageData();
        }
        public List<UserModelLibrary> GetUserDataforUpdatePage(int userId)
        {
            return dal.GetUserForUpdatePage(userId);
        }
        public bool UpdateUser(int userId, UserModelLibrary value)
        {
            return dal.UserUpdate(userId,value);
        }
        public bool SoftDeleteUser(int userId, int isDeleted)
        {
            return dal.SoftDelete(userId, isDeleted);
        }
    }
}
