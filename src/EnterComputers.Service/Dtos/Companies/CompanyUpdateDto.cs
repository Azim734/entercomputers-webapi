using Microsoft.AspNetCore.Http;

namespace EnterComputers.Service.Dtos.Companies;

public class CompanyUpdateDto
{
    public string Name { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public IFormFile? Image { get; set; } 
}
