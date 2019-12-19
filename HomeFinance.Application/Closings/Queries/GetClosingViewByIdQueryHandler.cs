using Microsoft.EntityFrameworkCore;
using HomeFinance.Persistence;
using HomeFinance.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace HomeFinance.Application.Closings.Queries
{
    public class GetClosingViewByIdQueryHandler : IRequestHandler<GetClosingViewByIdQuery, ClosingViewModel>
    {
        private readonly HomeFinanceDbContext _context;

        public GetClosingViewByIdQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<ClosingViewModel> Handle(GetClosingViewByIdQuery request, CancellationToken cancellationToken)
        {

            return await _context.ViewClosings
                 .Where(q => q.Id == request.Id)
                 .Select(q => new ClosingViewModel
                 {
                     Id = q.Id,
                     CardName = q.CardName,
                     ClosingDate = q.ClosingDate,
                     ClosingAmount = q.ClosingAmount,
                     ClosingName = q.ClosingName
                 })
                 .SingleOrDefaultAsync();
        }
    }
}