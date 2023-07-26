using EnterComputers.Service.Dtos.Auth;
using FluentValidation;

namespace EnterComputers.Service.Validators.Dtos.Auth;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname is required!")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname is required!")
          .MaximumLength(30).WithMessage("Lastname must be less than 30 characters");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidator.IsValed(phone))
            .WithMessage("Phone number is invaled! ex (+998XXYYYAABB)");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Pasword is not strong password!");
    }
}
