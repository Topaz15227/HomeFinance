using MediatR;
using System.Collections.Generic;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.StorePays.Queries
{
    public class GetStorePaysByStoreQuery : IRequest<List<ViewStorePays>>
    {
        public int StoreId { get; set; }
    }
}
