using MediatR;
using Microsoft.EntityFrameworkCore;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Domain.Entities;
using System.Linq.Dynamic.Core;

namespace HomeFinance.Application.Closings.Queries
{
    public class GetClosingsQueryHandler : IRequestHandler<GetClosingsQuery, ClosingListViewModel>
    {
        private readonly HomeFinanceDbContext _context;

        public GetClosingsQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<ClosingListViewModel> Handle(GetClosingsQuery request, CancellationToken cancellationToken)
        {
            var response = new ClosingListViewModel();
            var data = _context.ViewClosings
                .Where(q => request.CardId == 0 || q.CardId == request.CardId);


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

            response.ClosingListData = await data.Select(q => new ClosingViewModel
            {
                Id = q.Id,
                CardName = q.CardName,
                ClosingDate = q.ClosingDate,
                ClosingAmount = q.ClosingAmount,
                ClosingName = q.ClosingName
            }).ToListAsync();

            return response;
        }
    }
}