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
    public class GetNextClosingNumberQueryHandler : IRequestHandler<GetNextClosingNumberQuery, string>
    {
        private readonly HomeFinanceDbContext _context;

        public GetNextClosingNumberQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(GetNextClosingNumberQuery request, CancellationToken cancellationToken)
        {
            string nextNumber = string.Empty;

            var lastNumber = await _context.Closings
                .Where(q => q.CardId == request.CardId)
                .OrderByDescending(q => q.Id)
                .Select(q => q.ClosingName)
                .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(lastNumber))
            {
                nextNumber = await _context.Cards
                    .Where(q => q.Id == request.CardId)
                    .Select(q => q.ClosingName)
                     .FirstOrDefaultAsync() + "-1";
            }
            else
            {
                int pos1 = lastNumber.IndexOf("-");
                string _num = lastNumber.Substring(pos1 + 1);

                int pos2 = lastNumber.IndexOf(" ");
                if (pos2 > pos1)
                {
                    _num = lastNumber.Substring(pos1 + 1, pos2 - pos1 - 1);
                }

                nextNumber = lastNumber.Substring(0, pos1 + 1) + (int.Parse(_num) + 1).ToString();
            }
            return nextNumber;

        }
    }
}
