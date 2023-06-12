using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Admin, int, Admin> AdminData() //no CRUD here
        {
            return new AdminRepo();
        }
        public static IRepo<Courier, int, Courier> CourierData()
        {
            return new CourierRepo();
        }
        public static IRepo<CustomerInfo, int, CustomerInfo> CustomerInfoData()
        {
            return new CustomerInfoRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }
    }
}
