using MediatR;
using System.Collections.Generic;

namespace HomeFinance.Application.Cards.Queries
{
    public class GetCardExtendedListQuery : IRequest<List<CardListViewModel>>
    {
    }
}
