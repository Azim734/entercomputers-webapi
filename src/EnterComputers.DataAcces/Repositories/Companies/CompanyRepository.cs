using Dapper;
using EnterComputers.DataAcces.Interfaces.Companies;
using EnterComputers.DataAcces.Utils;
using EnterComputers.Domain.Entities.Categories;
using EnterComputers.Domain.Entities.Companies;

namespace EnterComputers.DataAcces.Repositories.Companies;

public class CompanyRepository : BaseRepository, ICompanyRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT count(*) FROM companies";
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

    public async Task<int> CreateAsync(Company entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.companies(name, description, image_path, phone_number, created_at, updated_at)" +
                "VALUES (@Name, @Description, @Imagepath, @Phonenumber, @Createdat, @Updatedat);";
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"delete from companies where id = Id";
            var result = await _connection.ExecuteAsync(query, new {Id = id });
            return result;
        }
        catch 
        {

            return 0;
        }
        finally
        {
            await _connection.CloseAsync() ;
        }
    }

    public async Task<IList<Company>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM companies order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Company>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Company>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Company?> GetByIdAsync(long id) 
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM companies where id = {id}";
            var result = await _connection.QuerySingleAsync<Company>(query);
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

    public async Task<int> UpdateAsync(long id, Company entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.companies " +
                "SET name=@Name, description=@Description, image_path=@Imagepath," +
                " phone_number=@Phonenumber, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $"WHERE id={id};";
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
}
