using Dapper;
using EnterComputers.DataAcces.Interfaces.Users;
using EnterComputers.DataAcces.Utils;
using EnterComputers.DataAcces.ViewModels.Users;
using EnterComputers.Domain.Entities.Users;
using static Dapper.SqlMapper;

namespace EnterComputers.DataAcces.Repositories.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT count(*) FROM categories";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.users(first_name, last_name, phone_number, phone_number_confirmed, passport_seria_number, is_male, birth_date, country, region, password_hash, salt, image_path, last_activity, IdentityRole, created_at, updated_at) " +
                "VALUES (@FirstName, @LastName, @PhoneNumber, @PhoneNumberConfirmed, @PassportSeriaNumber, @IsMale, @BirthDate, @Country, @Region, @PasswordHash, @Salt, @ImagePath, @LastActivity, @IdentityRole, @CreatedAt, @UpdatedAt);";
            return await _connection.ExecuteAsync(query, entity);

        }
        catch 
        {

            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"delete from users where id = {id}";
            return await _connection.ExecuteAsync(query);

        }
        catch
        {

            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<IList<User>> GetAllAsync(PaginationParams @params)
    {

        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT id,first_name,last_name,phone_number,birth_date, country, region,last_activity, IdentityRole FROM public.users ORDER BY id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<User>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<User>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<User?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT id,first_name,last_name,phone_number,birth_date, country, region,last_activity, IdentityRole FROM public.users  where id = {id}";
            var result = await _connection.QuerySingleAsync<User>(query);
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<User?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * from users where phone_number = @PhoneNumber";
            var data = await _connection.QuerySingleAsync<User>(query, new { PhoneNumber = phone });
            return data;
        }
        catch 
        {

            return null;
        }
        finally
        {
            await _connection.CloseAsync() ;
        }
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.users " +
                "SET first_name=@FirstName, last_name=@LastName, phone_number=@PhoneNumber, phone_number_confirmed=@PhoneNumberConfirmed, passport_seria_number=@PassportSeriaNumber, is_male=@IsMale, birth_date=@BirthDate, country=@Country, region=@Region, password_hash=@PasswordHash, salt=@Salt, image_path=@ImagePath, last_activity=@LastActivity, IdentityRole=@IdentityRole, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                "WHERE id=@Id;";

            entity.Id = id;
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }


    public async Task<(int ItemsCount, IList<User>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

}
