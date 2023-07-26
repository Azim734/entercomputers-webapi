using EnterComputers.Service.Dtos.Auth;

namespace EnterComputers.Service.Interfaces.Auth;

public interface IAuthService
{
    public Task<(bool result, int CachedMinutes)> RegisterAsync(RegisterDto dto);

    public Task<(bool result, int CachedVerificationMinuted)> SendCodeForRegisterAsync(string phone);

    public Task<(bool result, string token)> VerifyRegisterAsync(string phone, int code);
}
