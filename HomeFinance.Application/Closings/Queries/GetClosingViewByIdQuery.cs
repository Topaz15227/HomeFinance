using MediatR;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Closings.Queries
{
    public class GetClosingViewByIdQuery : IRequest<ClosingViewModel>
    {
        public int Id { get; set; }
    }
}
