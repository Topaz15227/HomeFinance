using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HomeFinance.Persistence;
using HomeFinance.Domain.Entities;
using HomeFinance.Application.Exceptions;

namespace HomeFinance.Application.StorePays.Commands
{
    public class UpdateStorePayCommandHandler : IRequestHandler<UpdateStorePayCommand, Unit>
    {
        private readonly HomeFinanceDbContext _context;

        public UpdateStorePayCommandHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateStorePayCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.StorePays.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(StorePay), request.Id);
            }

            entity.PayDate = request.PayDate;
            entity.CardId = request.CardId;
            entity.StoreId = request.StoreId;
            entity.Amount = request.Amount;
            entity.Note = request.Note;
            entity.Active = request.Active;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
