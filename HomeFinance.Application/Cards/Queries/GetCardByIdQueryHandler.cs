//using Microsoft.EntityFrameworkCore;
using HomeFinance.Application.Exceptions;
using HomeFinance.Persistence;
using HomeFinance.Domain.Entities;
//using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace HomeFinance.Application.Cards.Queries
{
    public class GetCardByIdQueryHandler : IRequestHandler<GetCardByIdQuery, Card>
    {
        private readonly HomeFinanceDbContext _context;

        public GetCardByIdQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Card> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
        {
            //var card = await _context
            //    .Cards.Where(p => p.Id == request.Id)
            //    .SingleOrDefaultAsync(cancellationToken);

            var card = await _context.Cards
                .FindAsync(request.Id);

            if (card == null)
            {
                throw new NotFoundException(nameof(Card), request.Id);
            }
            return card;
        }
    }
}
