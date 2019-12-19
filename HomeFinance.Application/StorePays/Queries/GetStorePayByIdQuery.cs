using MediatR;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.StorePays.Queries
{
    public class GetStorePayByIdQuery : IRequest<StorePay>
    {
        public int Id { get; set; }
    }
}
