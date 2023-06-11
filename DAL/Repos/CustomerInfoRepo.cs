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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerInfo> Get()
        {
            throw new NotImplementedException();
        }

        public CustomerInfo Get(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerInfo Update(CustomerInfo obj)
        {
            throw new NotImplementedException();
        }
    }
}
