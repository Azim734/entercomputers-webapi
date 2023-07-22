using EnterComputers.DataAcces.Interfaces.Categories;
using EnterComputers.Domain.Entities.Categories;
using EnterComputers.Domain.Exceptions.Categories;
using EnterComputers.Domain.Exceptions.Files;
using EnterComputers.Service.Common.Helpers;
using EnterComputers.Service.Dtos.Categories;
using EnterComputers.Service.Interfaces.Categories;
using EnterComputers.Service.Interfaces.Common;
using System.IO;

namespace EnterComputers.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _reposetory;
    private IFileService _fileService;

    public CategoryService(ICategoryRepository categoryRepository,
        IFileService fileService)
    {
        this._reposetory = categoryRepository;
        this._fileService = fileService;
    }

    public async Task<long> CountAsync()=> await _reposetory.CountAsync();

    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        string imagepath = await _fileService.UploadAvatarAsync(dto.Image);
        Category category = new Category()
        {
            ImagePath = imagepath,
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };
        var result = await _reposetory.CreateAsync(category);
        return result > 0;  
    }

    public async Task<bool> DeleteAsync(long categoryId)
    {
        var category = await _reposetory.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundExcaption();

        var result = await _fileService.DeleteImageAsync(category.ImagePath);
        if (result ==false  ) throw new ImageNotFoundException();

        var dbResult = await _reposetory.DeleteAsync(categoryId);
        return dbResult > 0;

    }

    Task<bool> ICategoryService.CountAsync()
    {
        throw new NotImplementedException();
    }
}
