using EnterComputers.DataAcces.Interfaces.Companies;
using EnterComputers.DataAcces.Utils;
using EnterComputers.Domain.Entities.Companies;
using EnterComputers.Domain.Exceptions.Categories;
using EnterComputers.Service.Common.Helpers;
using EnterComputers.Service.Dtos.Categories;
using EnterComputers.Service.Dtos.Companies;
using EnterComputers.Service.Interfaces.Common;
using EnterComputers.Service.Interfaces.Companies;
using EnterComputers.Service.Services.Common;
using System.ComponentModel.Design;

namespace EnterComputers.Service.Services.Companies;

public class CompaniService : IcompanyService
{
    private readonly ICompanyRepository _repository;
    private readonly IFileService _fileservice;

    public CompaniService(ICompanyRepository companyRepository,
        IFileService fileService)
    {
        this._repository = companyRepository;
        this._fileservice = fileService;
    }
    public async Task<bool> CreateAsync(CompanyCreateDto dto)
    {
        string imagepath = await _fileservice.UploadImageAsync(dto.Image);
        Company company= new Company();
        company.Name = dto.Name;
        company.Description = dto.Description;  
        company.PhoneNumber = dto.PhoneNumber;
        company.ImagePath = imagepath;
        company.CreatedAt = company.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.CreateAsync(company);
        return dbResult > 0;    

    }

    public async Task<bool> DeleteAsync(long companyId)
    {
        var company = await _repository.GetByIdAsync(companyId);
        if (company is null) throw new CategoryNotFoundExcaption();
        else
        {
            await _fileservice.DeleteImageAsync(company.ImagePath);
            var result = await _repository.DeleteAsync(companyId);
            return result > 0;
        }
    }

    public async Task<IList<Company>> GetAllAsync(PaginationParams @params)
    {
        var companies = await _repository.GetAllAsync(@params);
        /*
         * pagination
         */
        return companies;
    }

    public async Task<Company> GetAllAsync(long companyId)
    {
        var company = await _repository.GetByIdAsync(companyId);
        if (company is null) throw new CategoryNotFoundExcaption();
        else return company;
    }

    async Task<bool> IcompanyService.UpdateAsync(long companyId, CompanyUpdateDto dto)
    {
        var company = await _repository.GetByIdAsync(companyId);
        if (company is null) throw new CategoryNotFoundExcaption();

        company.Name = dto.Name;
        company.Description = dto.Description;
        company.PhoneNumber = dto.PhoneNumber;

        if (dto.Image is not null)
        {
            await _fileservice.DeleteImageAsync(company.ImagePath);
            company.ImagePath = await _fileservice.UploadImageAsync(dto.Image);
        }

        company.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(companyId, company);
        return dbResult > 0;
    }
}
