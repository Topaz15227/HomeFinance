using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HomeFinance.Persistence;
using HomeFinance.Domain.Entities;
using HomeFinance.Application.Exceptions;

namespace HomeFinance.Application.Cards.Commands
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand, Unit>
    {
        private readonly HomeFinanceDbContext _context;

        public UpdateCardCommandHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cards.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Card), request.Id);
            }

            entity.CardName = request.CardName;
            entity.CardDescription = request.CardDescription;
            entity.CardNumber = request.CardNumber;
            entity.ClosingName = request.ClosingName;
            entity.Active = request.Active;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}