using MediatR;
using Microsoft.EntityFrameworkCore;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Domain.Entities;
using System.Linq.Dynamic.Core;

namespace HomeFinance.Application.Stores.Queries
{
    public class GetStoresQueryHandler : IRequestHandler<GetStoresQuery, StoreListModel>
    {
        private readonly HomeFinanceDbContext _context;

        public GetStoresQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<StoreListModel> Handle(GetStoresQuery request, CancellationToken cancellationToken)
        {
            var response = new StoreListModel();
            var data = _context.Stores
                .Select(q => q);


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

            response.StoreListData = await data.Select(q => q)
            .ToListAsync();

            return response;
        }

    }
}