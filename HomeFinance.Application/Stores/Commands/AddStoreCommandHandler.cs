using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HomeFinance.Persistence;

namespace HomeFinance.Application.Stores.Commands
{
    public class AddStoreCommandHandler : IRequestHandler<AddStoreCommand, int>
    {
        private readonly HomeFinanceDbContext _context;

        public AddStoreCommandHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = new HomeFinance.Domain.Entities.Store
            {
                StoreName = request.StoreName,
                Active = request.Active ?? true
            };

            _context.Stores.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}