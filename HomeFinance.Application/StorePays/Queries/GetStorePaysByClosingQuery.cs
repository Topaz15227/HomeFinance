using MediatR;

namespace HomeFinance.Application.StorePays.Queries
{
    public class GetStorePaysByClosingQuery : IRequest<ClosingPayListViewModel>
    {
        public int ClosingId { get; set; }
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}