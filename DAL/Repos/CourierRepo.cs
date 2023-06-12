using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourierRepo : DBRepo, IRepo<Courier, int, Courier>
    {
        public Courier Create(Courier obj)
        {
            db.Couriers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exC = Get(id);
            db.Couriers.Remove(exC);
            return db.SaveChanges() > 0;
        }

        public List<Courier> Get()
        {
            return db.Couriers.ToList();
        }

        public Courier Get(int id)
        {
            return db.Couriers.Find(id);
        }

        public Courier Update(Courier obj)
        {
            var exCourier = Get(obj.ConsignmentNo);
            db.Entry(exCourier).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
