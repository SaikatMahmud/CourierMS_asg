using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : DBRepo, IRepo<User, string, User>, IAuth<bool>
    {
        public bool Authenticate(string Username, string Password)
        {
            throw new NotImplementedException();
        }

        public User Create(User obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string username)
        {
            throw new NotImplementedException();
        }

        public List<User> Get()
        {
            throw new NotImplementedException();
        }

        public User Get(string username)
        {
            throw new NotImplementedException();
        }

        public User Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
