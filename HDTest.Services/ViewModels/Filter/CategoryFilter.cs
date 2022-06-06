using HuceDocs.Services.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ViewModels.Filter
{
    public class CategoryFilter : PagingRequestBase
    {
        public string NameOrCode { get; set; }
    }
}
