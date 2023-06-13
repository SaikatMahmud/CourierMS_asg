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
            var data = DataAccessFactory.IPDAdmitData().Get();
            DateTime currentDate = DateTime.Today;
            DateTime sixMonthsAgo = currentDate.AddMonths(-7);

            var fetched = data
                .Where(x => x.AdmitDate >= sixMonthsAgo && x.AdmitDate <= currentDate)
                .GroupBy(x => new { Month = x.AdmitDate.Month })
                .Select(g => new { Month = g.Key.Month, PatientCount = (g.Select(x => x.PatientId).Count()) })
                .OrderByDescending(x => x.Month)
                .ToList();
            var result = fetched.Select(x => new StatDTO
            {
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Month),
                IPDPtCount = x.PatientCount
            }).ToList();
            return result;
        }
    }
}
