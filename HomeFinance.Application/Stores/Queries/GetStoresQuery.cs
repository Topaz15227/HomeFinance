using MediatR;
using System.Collections.Generic;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Stores.Queries
{
    public class GetStoresQuery : IRequest<StoreListModel>
    {
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}