using EnterComputers.Service.Dtos.Media;
using Microsoft.AspNetCore.Mvc;

namespace EnterComputers.WebApi.Controllers;

[Route("api/media")]
[ApiController]
public class MediaController : ControllerBase
{
    [HttpPost("images")]
    public async Task<string> CreateImageAsync([FromForm] ImageCreateDto imageDto)
    {
        return "";
    }

    [HttpPost("avatar")]
    public async Task<string> CreateAvatarAsync([FromForm] AvatarCreateDto avatarDto)
    {
        return "";
    }
}
