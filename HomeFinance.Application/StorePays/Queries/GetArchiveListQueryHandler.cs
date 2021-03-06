﻿using MediatR;
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
    public class GetArchiveListQueryHandler : IRequestHandler<GetArchiveListQuery, ArchiveListViewModel>
    {
        private readonly HomeFinanceDbContext _context;

        public GetArchiveListQueryHandler(HomeFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<ArchiveListViewModel> Handle(GetArchiveListQuery request, CancellationToken cancellationToken)
        {
            var response = new ArchiveListViewModel();
            var data = _context.ViewStorePays
                .Where(q => q.ClosingId.HasValue && (request.CardId == 0 || q.CardId == request.CardId));

            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                data = data.Where(q => q.CardName.Contains(request.Filter)
                || q.StoreName.Contains(request.Filter)
                || (!string.IsNullOrEmpty(q.Note)
                && q.Note.Contains(request.Filter)));
            }

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

            response.ArchiveListData = await data.Select(q => new ArchiveViewModel
            {
                Id = q.Id,
                PayDate = q.PayDate,
                CardName = q.CardName,
                StoreName = q.StoreName,
                Amount = q.Amount,
                Note = q.Note,
                ClosingDate = q.ClosingDate.Value,
                ClosingId = q.ClosingId.Value
            }).ToListAsync();

            return response;
        }
    }
}