using MediatR;

namespace HomeFinance.Application.StorePays.Queries
{
    public class GetStorePayListQuery : IRequest<StorePayListViewModel>
    {
        public int CardId { get; set; }
        public string Filter { get; set; }
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
