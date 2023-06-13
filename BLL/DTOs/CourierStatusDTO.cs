using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourierStatusDTO
    {
        public int TotalConsignmentThisMonth { get; set; }
        public int TotalRevenueThisMonth { get; set; }
        public int ShipmentPending { get; set; }
        public int TotalDeliveredThisMonth { get; set; }

    }
}
