using System;
using System.Collections.Generic;

namespace HuceDocs.Services.ViewModels.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public PagedResult() { }
        public PagedResult(int pageNumber, int pageSize, int totalNumberOfItem)
        {
            if (pageSize <= 0)
                throw new ArgumentException("pageSize must be larger than 0", nameof(pageSize));
            var numberOfPages = (int)Math.Ceiling(totalNumberOfItem / (double)pageSize);
            var actualPageIndex = pageNumber <= 0 ? 1 : pageNumber;

            if (actualPageIndex > numberOfPages)
                actualPageIndex = 1;

            var itemStartIndex = (actualPageIndex - 1) * pageSize;
            var itemEndIndex = itemStartIndex + pageSize - 1;
            itemEndIndex = itemEndIndex > totalNumberOfItem - 1 ? totalNumberOfItem - 1 : itemEndIndex;

            PageIndex = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalNumberOfItem;
        }
        public List<T> Items { set; get; }
    }
}