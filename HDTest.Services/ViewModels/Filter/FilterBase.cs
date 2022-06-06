using HuceDocs.Services.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ModelFilter
{
    public class FilterBase : PagingRequestBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
