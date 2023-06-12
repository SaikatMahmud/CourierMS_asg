using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CustomerInfoRepo : DBRepo, IRepo<CustomerInfo, int, CustomerInfo>
    {
        public CustomerInfo Create(CustomerInfo obj)
        {
            db.CustomerInfos.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exD = Get(id);
            db.CustomerInfos.Remove(exD);
            return db.SaveChanges() > 0;
        }

        public List<CustomerInfo> Get()
        {
            return db.CustomerInfos.ToList();
        }

        public CustomerInfo Get(int id)
        {
            return db.CustomerInfos.Find(id);
        }

        public CustomerInfo Update(CustomerInfo obj)
        {
            var exCustomerInfo = Get(obj.ConsignmentNo);
            db.Entry(exCustomerInfo).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
