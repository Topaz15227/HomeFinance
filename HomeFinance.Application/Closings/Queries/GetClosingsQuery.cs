using MediatR;

namespace HomeFinance.Application.Closings.Queries
{
    public class GetClosingsQuery : IRequest<ClosingListViewModel>
    {
        public int CardId { get; set; }
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
