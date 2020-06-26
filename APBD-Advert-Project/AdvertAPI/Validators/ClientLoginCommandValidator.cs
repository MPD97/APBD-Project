using Advert.Presistance.Mediator.Commands;
using FluentValidation;

namespace Advert.API.Validators
{
    public class ClientLoginCommandValidator : AbstractValidator<ClientLoginCommand>
    {
        public ClientLoginCommandValidator()
        {
            RuleFor(a => a.Login)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(15);

            RuleFor(a => a.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(20);
        }
    }
}