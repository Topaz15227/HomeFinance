using MediatR;
using System.Collections.Generic;

namespace HomeFinance.Application.Stores.Queries
{
    public class GetStoreListQuery : IRequest<List<StoreListViewModel>>
    {
    }
}
