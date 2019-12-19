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
    public class GetStorePaysQueryHandler : IRequestHandler<GetStorePaysQuery, List<ViewStorePays>>
    {
        private readonly HomeFinanceDbContext _context;

        public GetStorePaysQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<ViewStorePays>> Handle(GetStorePaysQuery request, CancellationToken cancellationToken)
        {

            var data = _context.ViewStorePays
                .Where(q => !q.ClosingId.HasValue && (request.CardId == 0 || q.CardId == request.CardId))
                .OrderByDescending(q => q.Id);

            return await data.ToListAsync();
        }
    }
}
