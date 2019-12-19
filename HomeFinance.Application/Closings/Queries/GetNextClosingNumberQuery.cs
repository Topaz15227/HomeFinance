using MediatR;

namespace HomeFinance.Application.Closings.Queries
{
    public class GetNextClosingNumberQuery : IRequest<string>
    {
        public int CardId { get; set; }
    }
}
