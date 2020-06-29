using Advert.Presistance.Mediator.Commands;
using FluentValidation;

namespace Advert.API.Validators
{
    public class ClientRefreshTokenCommandValidator : AbstractValidator<ClientRefreshTokenCommand>
    {
        public ClientRefreshTokenCommandValidator()
        {
            RuleFor(a => a.Token)
                .NotEmpty();

            RuleFor(a => a.RefreshToken)
                .NotEmpty();
        }
    }
}