using HuceDocs.Services.ViewModels.Common;

namespace HuceDocs.Services.ViewModels.User
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }

    public class GetEmployeePagingRequest : PagingRequestBase
    {
        public int ParrentId { get; set; }
        public int? Status { get; set; }
        public double? AmountSpentFrom { get; set; }
        public double? AmountSpentTo { get; set; }
        public string Keyword { get; set; }
    }
    public class GetDocumentsPagingRequest : PagingRequestBase
    {
        public int ParrentId { get; set; }
    }
}