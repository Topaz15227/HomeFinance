using MediatR;
using System.Collections.Generic;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.StorePays.Queries
{
    public class GetSummaryQuery : IRequest<List<ViewCardPays>>
    {
    }
}
