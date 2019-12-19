using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HomeFinance.Persistence;
using HomeFinance.Domain.Entities;
using HomeFinance.Application.Exceptions;

namespace HomeFinance.Application.Stores.Commands
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, Unit>
    {
        private readonly HomeFinanceDbContext _context;

        public UpdateStoreCommandHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Stores.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Store), request.Id);
            }

            entity.StoreName = request.StoreName;
            entity.Active = request.Active;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
