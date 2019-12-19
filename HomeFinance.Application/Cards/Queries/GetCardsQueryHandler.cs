using MediatR;
using Microsoft.EntityFrameworkCore;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Cards.Queries
{
    public class GetCardsQueryHandler : IRequestHandler<GetCardsQuery, List<Card>>
    {
        private readonly HomeFinanceDbContext _context;

        public GetCardsQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Card>> Handle(GetCardsQuery request, CancellationToken cancellationToken)
        {

            var data = _context.Cards
                .OrderBy(q => q.Id);

            return await data.ToListAsync();
        }
    }
}
