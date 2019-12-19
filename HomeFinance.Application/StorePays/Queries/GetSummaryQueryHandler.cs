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
    public class GetSummaryQueryHandler : IRequestHandler<GetSummaryQuery, List<ViewCardPays>>
    {
        private readonly HomeFinanceDbContext _context;

        public GetSummaryQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<ViewCardPays>> Handle(GetSummaryQuery request, CancellationToken cancellationToken)
        {

            var data = _context.ViewCardPays
                .OrderBy(q => q.Id);

            return await data.ToListAsync();
        }
    }
}