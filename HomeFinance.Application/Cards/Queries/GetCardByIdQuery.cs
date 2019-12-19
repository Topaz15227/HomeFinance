using MediatR;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Cards.Queries
{
    public class GetCardByIdQuery : IRequest<Card>
    {
        public int Id { get; set; }
    }
}
