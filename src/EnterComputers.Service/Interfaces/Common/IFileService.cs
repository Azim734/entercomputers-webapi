using Microsoft.AspNetCore.Http;

namespace EnterComputers.Service.Interfaces.Common;

public interface IFileService
{
    // return sub path of this image 
    public Task<string> UploadImageAsync(IFormFile image);

    public Task<bool> DeleteImageAsync(string subpath);
    // return sub path of this avatar
    public Task<string> UploadAvatarAsync(IFormFile avatar);

    public Task<bool> DeleteAvatarAsync(string subpath);

}
