using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
 
    public class ReportService
    {
        public static CourierStatusDTO GetStat()
        {
            var data = DataAccessFactory.CourierData().Get();
            DateTime currentMonth = DateTime.Now;
            var stat = new CourierStatusDTO()
            {
                TotalConsignmentThisMonth = data.Count(c => c.PlacingDate.Year == currentMonth.Year && c.PlacingDate.Month == currentMonth.Month),
                TotalRevenueThisMonth = data.Where(c => c.PlacingDate.Year == currentMonth.Year && c.PlacingDate.Month == currentMonth.Month)
                            .Sum(c => c.ShippingCost),
                ShipmentPending = data.Count(c => c.Status != "Delivered"),
                TotalDeliveredThisMonth =
                data.Count(c => c.Status == "Delivered" && c.PlacingDate.Year == currentMonth.Year && c.PlacingDate.Month == currentMonth.Month)
            };
            return stat;
        }
    }
}
