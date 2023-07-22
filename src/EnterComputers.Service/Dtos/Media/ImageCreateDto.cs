using Microsoft.AspNetCore.Http;

namespace EnterComputers.Service.Dtos.Media;

public class ImageCreateDto
{
    public IFormFile Feli { get; set; } = default!;
}
