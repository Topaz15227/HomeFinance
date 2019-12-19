using MediatR;
using System.Collections.Generic;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Cards.Queries
{
    public class GetCardsQuery : IRequest<List<Card>>
    {
    }
}
