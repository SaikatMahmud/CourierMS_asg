using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustomerInfoDTO
    {
        public int ConsignmentNo { get; set; }
        public string SenderName { get; set; }
        public string SenderMobile { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMobile { get; set; }
        public string ReceiverAddress { get; set; }
    }
}
