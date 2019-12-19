using MediatR;
using Microsoft.EntityFrameworkCore;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.StorePays.Queries
{
    public class GetStorePaysByStoreQueryHandler : IRequestHandler<GetStorePaysByStoreQuery, List<ViewStorePays>>
    {
        private readonly HomeFinanceDbContext _context;

        public GetStorePaysByStoreQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<ViewStorePays>> Handle(GetStorePaysByStoreQuery request, CancellationToken cancellationToken)
        {

            var data = _context.ViewStorePays
                .Where(q => !q.ClosingId.HasValue && (request.StoreId == 0 || q.StoreId == request.StoreId))
                .OrderByDescending(q => q.Id);

            return await data.ToListAsync();
        }
    }
}