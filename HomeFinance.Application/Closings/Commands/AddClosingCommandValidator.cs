using FluentValidation;


namespace HomeFinance.Application.Closings.Commands
{
    public class AddClosingCommandValidator : AbstractValidator<AddClosingCommand>
    {
        public AddClosingCommandValidator()
        {
            RuleFor(x => x.ClosingDate).NotEmpty();
            RuleFor(x => x.CardId).NotEmpty();
            RuleFor(x => x.ClosingName).NotEmpty();
            RuleFor(x => x.ClosingAmount).NotEmpty();
        }
    }
}
