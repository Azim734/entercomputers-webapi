using EnterComputers.DataAcces.Utils;
using EnterComputers.DataAcces.ViewModels.Users;
using EnterComputers.Domain.Entities.Users;
using EnterComputers.Service.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterComputers.Service.Interfaces.Users
{
    public interface IUserService
    {
        public Task<long> CreateAsync(UserCreateDto userCreateDto);

        public Task<bool> DeleteAsync(long id);

        public Task<long> CountAsync();

        public Task<IList<User>> GetAllAsync(PaginationParams @params);

        public Task<bool> UpdateAsync(long id, UserUpdateDto userUpdateDto);

    }
}
