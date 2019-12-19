using MediatR;
using Microsoft.EntityFrameworkCore;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Stores.Queries
{
    public class GetAllStoresQueryHandler : IRequestHandler<GetAllStoresQuery, List<Store>>
    {
        private readonly HomeFinanceDbContext _context;

        public GetAllStoresQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Store>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {

            var data = _context.Stores;
                //.OrderBy(q => q.Id);

            return await data.ToListAsync();
        }
    }
}