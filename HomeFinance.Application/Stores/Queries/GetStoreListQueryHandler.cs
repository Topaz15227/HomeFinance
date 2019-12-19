using MediatR;
using Microsoft.EntityFrameworkCore;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace HomeFinance.Application.Stores.Queries
{
    public class GetStoreListQueryHandler : IRequestHandler<GetStoreListQuery, List<StoreListViewModel>>
    {
        private readonly HomeFinanceDbContext _context;

        public GetStoreListQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<StoreListViewModel>> Handle(GetStoreListQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Stores
                .Where(q => q.Active == true)
                .Select(q => new StoreListViewModel
                {
                    Id = q.Id,
                    StoreName = q.StoreName
                })
                .OrderBy(q => q.StoreName)
                .ToListAsync(cancellationToken);

            return list;
        }
    }
}
