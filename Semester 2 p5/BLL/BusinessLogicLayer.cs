using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class BusinessLogicLayer
    {
        DataAccessLayer dal = new DataAccessLayer();

        public DataTable GetLogin(string Email, string Password)
        {
            return dal.GetLogin(Email, Password);
        }
        public int HardDeleteUser(int UserID)
        {
            return dal.HardDeleteUser(UserID);
        }
        public int UpdateUser(User U)
        {
            return dal.UpdateUser(U);
        }
        public int InsertUser(User U)
        {
            return dal.InsertUser(U);
        }
        public DataTable GetUser()
        {
            return dal.GetUser();
        }
        public DataTable GetRole()
        {
            return dal.GetRole();
        }
        public int InsertRole(User U)
        {
            return dal.InsertRole(U);
        }
        public int InsertCategory(User U)
        {
            return dal.InsertCategory(U);
        }
        public DataTable GetCategory()
        {
            return dal.GetCategory();
        }
        public int InsertPhoto(User U)
        {
            return dal.InsertPhoto(U);

        }
        public DataTable GetPhoto()
        {
            return dal.GetPhoto();
        }
        public int UpdatePhoto(User U)
        {
            return dal.UpdatePhoto(U);
        }

    }

}
