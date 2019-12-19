using MediatR;
using System.Collections.Generic;

namespace HomeFinance.Application.Cards.Queries
{
    public class GetCardListQuery : IRequest<List<CardListViewModel>>
    {
    }
}
