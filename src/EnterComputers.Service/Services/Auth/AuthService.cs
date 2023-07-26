using EnterComputers.DataAcces.Interfaces.Users;
using EnterComputers.Domain.Exceptions.Users;
using EnterComputers.Service.Common.Helpers;
using EnterComputers.Service.Dtos.Auth;
using EnterComputers.Service.Dtos.Notification;
using EnterComputers.Service.Dtos.Security;
using EnterComputers.Service.Interfaces.Auth;
using EnterComputers.Service.Interfaces.Notification;
using Microsoft.Extensions.Caching.Memory;

namespace EnterComputers.Service.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserRepository _userRepository;
        private readonly ISmsSender _smsSender;
        private const int CACHED_MINUTES_FOR_REGISTER = 60;
        private const int CACHED_MINUTES_FOR_VERIFICATION = 5;
        private const string REGISTER_CACHE_KEY = "register_";
        private const string VERIFY_REGISTER_CACHE_KEY = "verify_register_";
        public AuthService(IMemoryCache memoryCache,
            IUserRepository userRepository, ISmsSender smsSender)
        {
            this._memoryCache = memoryCache;
            this._userRepository = userRepository;
            this._smsSender = smsSender;
        }
#pragma warning disable
        public async Task<(bool result, int CachedMinutes)> RegisterAsync(RegisterDto dto)
        {
            var user = await _userRepository.GetByPhoneAsync(dto.PhoneNumber);
            if (user is not null) throw new UserAlreadyExistsException(dto.PhoneNumber);

            // delete if exists by this phone number
            if (this._memoryCache.TryGetValue(dto.PhoneNumber, out RegisterDto cacheRegisterDto))
            {
                cacheRegisterDto.FirstName = cacheRegisterDto.FirstName;
                _memoryCache.Remove(dto.PhoneNumber);
            }
            else _memoryCache.Set(dto.PhoneNumber, dto,
                TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));

            return (result: true, CachedMinutes: CACHED_MINUTES_FOR_REGISTER);


        }

        public async Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string phone)
        {
            if (_memoryCache.TryGetValue(phone, out RegisterDto register))
            {
                VerificationDto verificationDto = new VerificationDto();
                verificationDto.Attempt = 0;
                verificationDto.CreatedAt = TimeHelper.GetDateTime();
                //make confirm code as random
                int confirmCode = 11111;
                _memoryCache.Set(phone, verificationDto,
                    TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));

                //sms sender::begin
                //sms sender::end
                return (result: true, CachedVerificationMinutes: CACHED_MINUTES_FOR_VERIFICATION);

            }
            else throw new UserCacheDataExpiredException();

        }

        public Task<(bool result, string token)> VerifyRegisterAsync(string phone, int code)
        {
            throw new Exception(); 
        }
    }
}
