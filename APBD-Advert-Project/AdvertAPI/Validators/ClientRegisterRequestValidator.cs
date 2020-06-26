using Advert.Presistance.Mediator.Commands;
using FluentValidation;

namespace Advert.API.Validators
{
    public class ClientRegisterRequestValidator : AbstractValidator<ClientRegisterCommand>
    {
        public ClientRegisterRequestValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(15)
                .Matches("^[A-Z]{1}[a-z]{1,14}$")
                .WithMessage("First name must start uppercase");

            RuleFor(a => a.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(15)
                .Matches("^[A-Z]{1}[a-z]{1,14}$")
                .WithMessage("Last name must start uppercase");

            RuleFor(a => a.Email)
                .NotEmpty()
                .Matches(
                    "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])")
                .WithMessage("Email is not in valid format");

            RuleFor(a => a.Phone)
                .NotEmpty()
                .Matches(@"^\d{9,15}$")
                .WithMessage("Phone can contain only digits");

            RuleFor(a => a.Login)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(15)
                .Matches(@"^[a-z0-9]{6,15}$")
                .WithMessage("Login can contain only lower case letters and digits.");

            RuleFor(a => a.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(20)
                .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$")
                .WithMessage("Password mus have at least one letter, one number and one special character.");

            RuleFor(a => a.RepeatPassword)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(20)
                .Equal(x => x.Password);
        }
    }

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