using HomeFinance.Application.Exceptions;
using HomeFinance.Persistence;
using HomeFinance.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace HomeFinance.Application.StorePays.Queries
{
    public class GetStorePayByIdQueryHandler : IRequestHandler<GetStorePayByIdQuery, StorePay>
    {
        private readonly HomeFinanceDbContext _context;

        public GetStorePayByIdQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<StorePay> Handle(GetStorePayByIdQuery request, CancellationToken cancellationToken)
        {
            var storePay = await _context.StorePays
                .FindAsync(request.Id);

            if (storePay == null)
            {
                throw new NotFoundException(nameof(StorePay), request.Id);
            }
            return storePay;
        }
    }
}
