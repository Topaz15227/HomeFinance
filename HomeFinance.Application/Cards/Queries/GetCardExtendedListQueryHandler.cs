using MediatR;
using Microsoft.EntityFrameworkCore;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace HomeFinance.Application.Cards.Queries
{
    public class GetCardExtendedListQueryHandler : IRequestHandler<GetCardExtendedListQuery, List<CardListViewModel>>
    {
        private readonly HomeFinanceDbContext _context;

        public GetCardExtendedListQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<CardListViewModel>> Handle(GetCardExtendedListQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Cards
                .Where(q => q.Active == true)
                .Select(q => new CardListViewModel
                {
                    Id = q.Id,
                    CardName = q.CardName
                })
                .OrderBy(q => q.CardName)
                .ToListAsync(cancellationToken);
            var extendedList = new List<CardListViewModel>();

            extendedList.Add(new CardListViewModel
            {
                Id = 0,
                CardName = "All"
            });

            foreach(var item in list)
            {
                extendedList.Add(item);
            }
            return extendedList;
        }
    }
}
