using FluentValidation;

namespace HomeFinance.Application.StorePays.Commands
{
    public class UpdateStorePayCommandValidator : AbstractValidator<UpdateStorePayCommand>
    {
        public UpdateStorePayCommandValidator()
        {
            RuleFor(x => x.PayDate).NotEmpty();
            RuleFor(x => x.CardId).NotEmpty();
            RuleFor(x => x.StoreId).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.Note).MaximumLength(45);
        }
    }
}