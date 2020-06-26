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

    public class CampaignCreateCommandValidator : AbstractValidator<CampaignCreateCommand>
    {
        public CampaignCreateCommandValidator()
        {
            RuleFor(a => a.IdClient)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(a => a.StartDate)
                .NotEmpty();

            RuleFor(a => a.EndDate)
                .NotEmpty()
                .GreaterThan(a => a.StartDate);

            RuleFor(a => a.PricePerSquareMeter)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(a => a.FromIdBuilding)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(a => a.ToIdBuilding)
                .NotEmpty()
                .GreaterThan(0)
                .GreaterThan(a => a.FromIdBuilding);
        }
    }
}