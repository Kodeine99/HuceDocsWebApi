﻿namespace HuceDocs.Services.ViewModels.Common
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}