using FluentValidation;

namespace HomeFinance.Application.Cards.Commands
{
    public class UpdateCardCommandValidator : AbstractValidator<UpdateCardCommand>
    {
        public UpdateCardCommandValidator()
        {
            RuleFor(x => x.CardName).NotEmpty().MaximumLength(15);
            RuleFor(x => x.CardDescription).NotEmpty().MaximumLength(25);
            RuleFor(x => x.CardNumber).NotEmpty().MaximumLength(20);
            RuleFor(x => x.ClosingName).NotEmpty().MaximumLength(3);
        }
    }
}