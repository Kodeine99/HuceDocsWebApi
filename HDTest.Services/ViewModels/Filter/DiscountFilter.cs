using HuceDocs.Services.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ViewModels.Filter
{
    public class DiscountFilter : PagingRequestBase
    {
        public int? UserId { get; set; }
        public int? FromPercent { get; set; }
        public int? ToPercent { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? FromAmount { get; set; }
        public double? ToAmount { get; set; }
        public bool? Active { get; set; }
    }
}
