using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Courier
    {
        [Key]
        public int ConsignmentNo { get; set; }
        public string ParcelType { get; set; }
        public string Weight { get; set; }
        public int ShippingCost { get; set; }
        public DateTime PlacingDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string CurrentLocation{ get; set; }
        public string Destination { get; set; }
        public int ETA { get; set; }
        public string Status { get; set; }
        public virtual CustomerInfo CustomerInfo { get; set; }

    }
}
