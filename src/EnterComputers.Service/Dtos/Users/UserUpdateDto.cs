using EnterComputers.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace EnterComputers.Service.Dtos.Users;

public class UserUpdateDto
{

    public string FirstName { get; set; } = string.Empty;



    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public string PassportSeriaNumber { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public DateTime BirthDate { get; set; }

    public string Country { get; set; } = string.Empty;


    public string Region { get; set; } = string.Empty;


    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    //public string ImagePath { get; set; } = string.Empty;
    public IFormFile ImagePath { get; set; } = default!;



    public DateTime LastActivity { get; set; }

    public IdentityRole Role { get; set; }

}
