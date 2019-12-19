using FluentValidation;

namespace HomeFinance.Application.Stores.Commands
{
    public class UpdateStoreCommandValidator : AbstractValidator<UpdateStoreCommand>
    {
        public UpdateStoreCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.StoreName).MaximumLength(30).NotEmpty();
        }
    }
}
