using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierMS_piistech.Filters
{
    public class FilterModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; } //search by consignment no only
        public FilterModel()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public FilterModel(int pageNumber, int pageSize)
        {
            this.PageNumber = (pageNumber < 1) ? 1 : pageNumber;
            this.PageSize = (pageSize >= 15) ? 15 : pageSize; //allow maximum 15 records per page
        }
    }
}