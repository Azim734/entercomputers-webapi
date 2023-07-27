using EnterComputers.Service.Dtos.Users;
using FluentValidation;

namespace EnterComputers.Service.Validators.Dtos.Users
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidator()
        {
            RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname is required!")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");

            RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname is required!")
            .MaximumLength(30).WithMessage("Lastname must be less than 30 characters");

            RuleFor(dto => dto.PhoneNumber).NotNull().NotEmpty().WithMessage("Phone number is required!");

            RuleFor(dto => dto.PassportSeriaNumber).NotNull().NotEmpty().WithMessage("Passport number is required!");

            RuleFor(dto => dto.BirthDate).NotNull().NotEmpty().WithMessage("Birth date is required!");

            RuleFor(dt0 => dt0.Region).NotEmpty().NotNull().WithMessage("Region is required!");


        }
    }
}
