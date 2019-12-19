using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HomeFinance.Persistence;

namespace HomeFinance.Application.Cards.Commands
{
    public class AddCardCommandHandler : IRequestHandler<AddCardCommand, int>
    {
        private readonly HomeFinanceDbContext _context;

        public AddCardCommandHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddCardCommand request, CancellationToken cancellationToken)
        {
            var entity = new HomeFinance.Domain.Entities.Card
            {
                CardName = request.CardName,
                CardDescription = request.CardDescription,
                CardNumber = request.CardNumber,
                ClosingName = request.ClosingName,
                Active = request.Active ?? true
            };

            _context.Cards.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}