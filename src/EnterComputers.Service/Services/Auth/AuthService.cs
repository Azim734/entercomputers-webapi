using EnterComputers.DataAcces.Interfaces.Users;
using EnterComputers.Domain.Exceptions.Users;
using EnterComputers.Service.Dtos.Auth;
using EnterComputers.Service.Interfaces.Auth;
using Microsoft.Extensions.Caching.Memory;

namespace EnterComputers.Service.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IMemoryCache _memoryCashe;
        private readonly IUserRepository _userRepository;
        private const int CACHED_MINUTES_FOR_REGISTER = 60;
        private const int CACHED_MINUTES_FOR_VERIFICATION = 5;  

        public AuthService(IMemoryCache memoryCache,
            IUserRepository userRepository)
        {
            this._memoryCashe = memoryCache;
            this._userRepository = userRepository;
        }
        public async Task<(bool result, int CachedMinutes)> RegisterAsync(RegisterDto dto)
        {
            var user = await _userRepository.GetByPhoneAsync(dto.PhoneNumber);
            if (user is not null) throw new UserAlreadyExistsException(dto.PhoneNumber);

            // delete if exists by this phone number
            if(_memoryCashe.TryGetValue(dto.PhoneNumber, out RegisterDto cacheRegisterDto))
            {
                cacheRegisterDto.FirstName = cacheRegisterDto.FirstName;
                _memoryCashe.Remove(dto.PhoneNumber);
            }
            else _memoryCashe.Set(dto.PhoneNumber, dto, 
                TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));

            return (result: true, CachedMinutes: CACHED_MINUTES_FOR_REGISTER);


        }

        public Task<(bool result, int CachedVerificationMinuted)> SendCodeForRegisterAsync(string phone)
        {
            throw new NotImplementedException();
        }

        public Task<(bool result, string token)> VerifyRegisterAsync(string phone, int code)
        {
            throw new NotImplementedException();
        }
    }
}
