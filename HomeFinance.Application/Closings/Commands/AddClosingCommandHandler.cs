using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using HomeFinance.Persistence;

namespace HomeFinance.Application.Closings.Commands
{
    public class AddClosingCommandHandler : IRequestHandler<AddClosingCommand, int>
    {
        private readonly HomeFinanceDbContext _context;

        public AddClosingCommandHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddClosingCommand request, CancellationToken cancellationToken)
        {
            var entity = new HomeFinance.Domain.Entities.Closing
            {
                ClosingDate = request.ClosingDate,
                CardId = request.CardId,
                ClosingName = request.ClosingName,
                ClosingAmount = request.ClosingAmount,
            };

            _context.Closings.Add(entity);
            _context.SaveChanges();
            if(entity.Id > 0)
            {
                var storePays = _context.StorePays.Where(q => q.CardId == request.CardId && !q.ClosingId.HasValue).ToList();
                foreach(var pay in storePays)
                {
                    if (pay.Active.Value)
                    {
                        pay.ClosingId = entity.Id;
                        pay.Active = false;
                    }
                    else
                    {
                        pay.Active = true;
                    }
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
