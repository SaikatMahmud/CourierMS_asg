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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Courier> Get()
        {
            throw new NotImplementedException();
        }

        public Courier Get(int id)
        {
            throw new NotImplementedException();
        }

        public Courier Update(Courier obj)
        {
            throw new NotImplementedException();
        }
    }
}
