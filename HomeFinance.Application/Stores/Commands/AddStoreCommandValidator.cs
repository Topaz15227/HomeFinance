using FluentValidation;

namespace HomeFinance.Application.Stores.Commands
{
    public class AddStoreCommandValidator : AbstractValidator<AddStoreCommand>
    {
        public AddStoreCommandValidator()
        {
            RuleFor(x => x.StoreName).MaximumLength(30).NotEmpty();
        }
    }
}
