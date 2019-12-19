using MediatR;
using Microsoft.EntityFrameworkCore;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace HomeFinance.Application.Cards.Queries
{
    public class GetCardListQueryHandler : IRequestHandler<GetCardListQuery, List<CardListViewModel>>
    {
        private readonly HomeFinanceDbContext _context;
  
        public GetCardListQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<CardListViewModel>> Handle(GetCardListQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Cards
                .Where(q => q.Active == true)
                .Select(q => new CardListViewModel
                {
                    Id = q.Id,
                    CardName = q.CardName
                })
                .OrderBy(q => q.CardName  )
                .ToListAsync(cancellationToken);

            return list;
        }
    }
}