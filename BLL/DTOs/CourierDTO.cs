using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourierDTO
    {
        public int ConsignmentNo { get; set; }
        public string ParcelType { get; set; }
        public string Weight { get; set; }
        public int ShippingCost { get; set; }
        public DateTime PlacingDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string CurrentLocation { get; set; }
        public string Destination { get; set; }
        public int ETA { get; set; } //estiamte time of arrival in days
        public string Status { get; set; }
    }
}
