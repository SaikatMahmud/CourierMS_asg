using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DBRepo
    {
        public static CMS_db db;
        public DBRepo()
        {
            db = new CMS_db();

        }
    }
}
