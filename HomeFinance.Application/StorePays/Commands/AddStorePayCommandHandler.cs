using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HomeFinance.Persistence;

namespace HomeFinance.Application.StorePays.Commands
{
    public class AddStorePayCommandHandler : IRequestHandler<AddStorePayCommand, int>
    {
        private readonly HomeFinanceDbContext _context;

        public AddStorePayCommandHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddStorePayCommand request, CancellationToken cancellationToken)
        {
            var entity = new HomeFinance.Domain.Entities.StorePay
            {
                PayDate = request.PayDate,
                CardId = request.CardId,
                StoreId = request.StoreId,
                Amount = request.Amount,
                Note = request.Note,
                ClosingId = null,
                Active = request.Active ?? true
            };

            _context.StorePays.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}