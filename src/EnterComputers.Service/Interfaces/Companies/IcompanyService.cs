using EnterComputers.DataAcces.Utils;
using EnterComputers.Domain.Entities.Companies;
using EnterComputers.Service.Dtos.Categories;
using EnterComputers.Service.Dtos.Companies;

namespace EnterComputers.Service.Interfaces.Companies;

public interface  IcompanyService
{
    public Task<bool> CreateAsync(CompanyCreateDto dto);

    public Task<IList<Company>> GetAllAsync(PaginationParams @params);

    public Task<Company> GetAllAsync(long companyId);

    public Task<bool> UpdateAsync(long companyId, CompanyUpdateDto dto);

    public Task<bool> DeleteAsync(long companyId);
}
