using MediatR;

namespace HomeFinance.Application.Cards.Commands
{
    public class AddCardCommand : IRequest<int>
    {
        public string CardName { get; set; }
        public string CardDescription { get; set; }
        public string CardNumber { get; set; }
        public string ClosingName { get; set; }
        public bool? Active { get; set; }
    }
}