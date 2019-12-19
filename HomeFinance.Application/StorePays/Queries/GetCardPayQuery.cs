using MediatR;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.StorePays.Queries
{
    public class GetCardPayQuery : IRequest<ViewCardPays>
    {
        public int CardId { get; set; }
    }
}