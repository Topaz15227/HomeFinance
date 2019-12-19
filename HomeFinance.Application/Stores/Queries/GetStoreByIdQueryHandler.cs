using HomeFinance.Application.Exceptions;
using HomeFinance.Persistence;
using HomeFinance.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace HomeFinance.Application.Stores.Queries
{
    public class GetStoreByIdQueryHandler : IRequestHandler<GetStoreByIdQuery, Store>
    {
        private readonly HomeFinanceDbContext _context;

        public GetStoreByIdQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Store> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var store = await _context.Stores
                .FindAsync(request.Id);

            if (store == null)
            {
                throw new NotFoundException(nameof(Store), request.Id);
            }
            return store;
        }
    }
}
