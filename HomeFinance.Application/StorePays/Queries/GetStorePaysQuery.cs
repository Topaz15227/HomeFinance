using MediatR;
using System.Collections.Generic;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.StorePays.Queries
{
    public class GetStorePaysQuery : IRequest<List<ViewStorePays>>
    {
        public int CardId { get; set; }
    }
}