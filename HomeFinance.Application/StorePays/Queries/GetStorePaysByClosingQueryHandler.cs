using MediatR;
using Microsoft.EntityFrameworkCore;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Domain.Entities;
using System.Linq.Dynamic.Core;

namespace HomeFinance.Application.StorePays.Queries
{
    public class GetStorePaysByClosingQueryHandler : IRequestHandler<GetStorePaysByClosingQuery, ClosingPayListViewModel>
    {
        private readonly HomeFinanceDbContext _context;

        public GetStorePaysByClosingQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<ClosingPayListViewModel> Handle(GetStorePaysByClosingQuery request, CancellationToken cancellationToken)
        {
            var response = new ClosingPayListViewModel();
            var data = _context.ViewStorePays
                .Where(q => q.ClosingId.HasValue && q.ClosingId.Value == request.ClosingId);


            if (!string.IsNullOrWhiteSpace(request.SortBy))
            {
                data = data.OrderBy($"{request.SortBy} {request.SortOrder}");
            }
            else
            {
                data = data.OrderByDescending(q => q.Id);
            }

            response.RowCount = await data.CountAsync();

            if (request.PageSize > 0)
            {
                int rowsSkipped = request.PageSize * (request.PageNumber - 1);

                if (response.RowCount > request.PageSize)
                    data = data.Skip(rowsSkipped).Take(request.PageSize);
            }

            response.ClosingPayListData = await data.Select(q => new ViewClosingPayModel
            {
                Id = q.Id,
                PayDate = q.PayDate,
                StoreName = q.StoreName,
                Amount = q.Amount,
                Note = q.Note
            }).ToListAsync();

            return response;
        }
    }
}
