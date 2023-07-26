using EnterComputers.Domain.Entities.Companies;
using EnterComputers.Service.Common.Helpers;
using EnterComputers.Service.Dtos.Companies;
using FluentValidation;

namespace EnterComputers.Service.Validators.Dtos.Companies;

public class CompanyUpdateValidation : AbstractValidator<CompanyUpdateDto>
{
    public CompanyUpdateValidation()
    {
        RuleFor(dto => dto.Name).NotEmpty().NotNull().WithMessage("Company name is required!")
   .MinimumLength(3).WithMessage("Company name must be more than 3 characters!")
   .MaximumLength(50).WithMessage("Company name must be less than 50 characters!");

        RuleFor(dto => dto.PhoneNumber).NotNull().NotEmpty().WithMessage("Company phone number is requerid!")
            .Must(phone => PhoneNumberValidator.IsValed(phone)).WithMessage("Phone number is incorrect!");

        When(dto => dto.Image is not null, () => 
        {
            int maxImageSizeMB = 5;
            RuleFor(dto => dto.Image!.Length).LessThan(maxImageSizeMB * 1024 * 1024).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.Image!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtension().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}
