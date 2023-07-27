using EnterComputers.DataAcces.Interfaces.Users;
using EnterComputers.DataAcces.Utils;
using EnterComputers.Domain.Entities.Users;
using EnterComputers.Domain.Exceptions;
using EnterComputers.Domain.Exceptions.Files;
using EnterComputers.Service.Common.Helpers;
using EnterComputers.Service.Common.Security;
using EnterComputers.Service.Dtos.Users;
using EnterComputers.Service.Interfaces.Common;
using EnterComputers.Service.Interfaces.Users;

namespace EnterComputers.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private IFileService _fileService;
    public UserService(IUserRepository userRepository, IFileService fileService)
    {
        this._userRepository = userRepository;
        this._fileService = fileService;
    }


    public async Task<long> CountAsync() => await _userRepository.CountAsync();


    public async Task<long> CreateAsync(UserCreateDto userCreateDto)
    {
        string imagepath = await _fileService.UploadImageAsync(userCreateDto.ImagePath);
        User user = new User()
        {
            FirstName = userCreateDto.FirstName,
            LastName = userCreateDto.LastName,
            PhoneNumber = userCreateDto.PhoneNumber,
            PhoneNumberConfirmed = userCreateDto.PhoneNumberConfirmed,
            PassportSeriaNumber = userCreateDto.PassportSeriaNumber,
            IsMale = userCreateDto.IsMale,
            BirthDate = userCreateDto.BirthDate,
            LastActivity = userCreateDto.LastActivity,
            Country = userCreateDto.Country,
            Region = userCreateDto.Region,
            Salt = userCreateDto.Salt,
            ImagePath = imagepath,
            Role = userCreateDto.Role,
        };
        var hashres = PasswordHasher.Hash(user.PasswordHash);
        user.Salt = hashres.Salt;
        user.PasswordHash = hashres.Hash;
        //user.PasswordHash = hashres.PasswordHash;
        var res = await _userRepository.CreateAsync(user);
        return res;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null) throw new NotFoundException();
        var res = await _fileService.DeleteImageAsync(user.ImagePath);
        if (res == false) throw new ImageNotFoundException();
        var dbRes = await _userRepository.DeleteAsync(id);
        return dbRes > 0;
    }

    public async Task<IList<User>> GetAllAsync(PaginationParams @params)
    {
        var users = await _userRepository.GetAllAsync(@params);
        return users;
    }

    public async Task<bool> UpdateAsync(long id, UserUpdateDto userUpdateDto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null) throw new NotFoundException();
        user.FirstName = userUpdateDto.FirstName;
        user.LastName = userUpdateDto.LastName;
        user.PhoneNumber = userUpdateDto.PhoneNumber;
        user.PhoneNumberConfirmed = userUpdateDto.PhoneNumberConfirmed;
        user.PassportSeriaNumber = userUpdateDto.PassportSeriaNumber;
        user.IsMale = userUpdateDto.IsMale;
        user.BirthDate = userUpdateDto.BirthDate;
        user.Country = userUpdateDto.Country;
        user.Region = userUpdateDto.Region;
        user.PasswordHash = userUpdateDto.PasswordHash;
        user.Salt = userUpdateDto.Salt;
        if (userUpdateDto.ImagePath is not null)
        {
            var deleteREs = await _fileService.DeleteImageAsync(user.ImagePath);
            if (deleteREs is false) throw new ImageNotFoundException();
            string newImagePath = await _fileService.UploadImageAsync(userUpdateDto.ImagePath);
            user.ImagePath = newImagePath;
        }
        user.UpdatedAt = TimeHelper.GetDateTime();
        var rbResult = await _userRepository.UpdateAsync(id, user);
        return rbResult > 0;
    }
}
