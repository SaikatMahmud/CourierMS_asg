using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CMS_db : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
