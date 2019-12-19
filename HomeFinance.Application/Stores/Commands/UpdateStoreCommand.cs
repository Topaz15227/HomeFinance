using MediatR;

namespace HomeFinance.Application.Stores.Commands
{
    public class UpdateStoreCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public bool? Active { get; set; }
    }
}
