using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CustomerInfo
    {
        [Key]
        [ForeignKey("Courier")]
        public int ConsignmentNo { get; set; }
        public string SenderName { get; set; }
        public string SenderMobile { get; set; }
        public string SenderAddress { get; set; }  
        public string ReceiverName { get; set; }
        public string ReceiverMobile { get; set; }
        public string ReceiverAddress { get; set; }  
        public virtual Courier Courier { get; set; }
    }
}
