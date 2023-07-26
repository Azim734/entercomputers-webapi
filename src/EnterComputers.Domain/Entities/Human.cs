using System.ComponentModel.DataAnnotations;

namespace EnterComputers.Domain.Entities;

public abstract class Human : Auditable
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;


    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    public string PassportSeriaNumber { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Country { get; set; } = string.Empty;

    public string Region { get; set; } = string.Empty;   

    public string ImagePath { get; set; } = string.Empty;

    public DateTime LastActivity { get; set; }

}
