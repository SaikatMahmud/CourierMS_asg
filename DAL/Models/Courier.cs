using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int Weight { get; set; }
        public int ShippingCost { get; set; }
        public DateTime PlacingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string CurrentLocation{ get; set; }
        public string FromLocation { get; set; }
        public string Destination { get; set; }
        public int? ETA { get; set; } //estiamte time of arrival in days
        public string Status { get; set; }
        public virtual CustomerInfo CustomerInfo { get; set; }

    }
}
