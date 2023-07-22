using Microsoft.AspNetCore.Http;

namespace EnterComputers.Service.Dtos.Media;

public class AvatarCreateDto
{
    public IFormFile Avatar { get; set; } = default!;
}
