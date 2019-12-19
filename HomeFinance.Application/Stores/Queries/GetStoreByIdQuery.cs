using MediatR;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Stores.Queries
{
    public class GetStoreByIdQuery : IRequest<Store>
    {
        public int Id { get; set; }
    }
}
