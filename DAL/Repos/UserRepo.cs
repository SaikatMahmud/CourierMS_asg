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
            //var data = db.Users.Where(x => x.Username == Username && x.Password == Password).FirstOrDefault();
            var data = db.Users.FirstOrDefault(u => u.Username.Equals(Username) && u.Password.Equals(Password));
            if (data != null) return true;
            return false;
        }
        public bool Delete(string uname)
        {
            var exU = Get(uname);
            db.Users.Remove(exU);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(string uname)
        {
            return db.Users.Find(uname);
        }

        public User Create(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public User Update(User obj)
        {
            // var exUser = db.Users.Find(obj.Username);
            var exUser = Get(obj.Username);
            db.Entry(exUser).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
