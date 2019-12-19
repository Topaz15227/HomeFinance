using MediatR;

namespace HomeFinance.Application.Stores.Commands
{
    public class AddStoreCommand : IRequest<int>
    {
        public string StoreName { get; set; }
        public bool? Active { get; set; }
    }
}
