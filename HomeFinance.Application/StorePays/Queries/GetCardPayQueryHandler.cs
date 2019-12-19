using MediatR;
using Microsoft.EntityFrameworkCore;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.StorePays.Queries
{
    public class GetCardPayQueryHandler : IRequestHandler<GetCardPayQuery, ViewCardPays>
    {
        private readonly HomeFinanceDbContext _context;

        public GetCardPayQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<ViewCardPays> Handle(GetCardPayQuery request, CancellationToken cancellationToken)
        {
            return await _context.ViewCardPays
                .Where(q => q.Id == request.CardId)
                .SingleOrDefaultAsync();
        }
    }
}
