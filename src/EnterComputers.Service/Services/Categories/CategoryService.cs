using EnterComputers.DataAcces.Interfaces.Categories;
using EnterComputers.DataAcces.Utils;
using EnterComputers.Domain.Entities.Categories;
using EnterComputers.Domain.Exceptions.Categories;
using EnterComputers.Domain.Exceptions.Files;
using EnterComputers.Service.Common.Helpers;
using EnterComputers.Service.Dtos.Categories;
using EnterComputers.Service.Interfaces.Categories;
using EnterComputers.Service.Interfaces.Common;

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

    public async Task<long> CountAsync()
    {
        var result =await _reposetory.CountAsync();
        return result;
    }

    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        string imagepath = await _fileService.UploadImageAsync(dto.Image);
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

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var categories = await _reposetory.GetAllAsync(@params);
        return categories;
    }

    public async Task<Category> GetByIdAsync(long categoryId)
    {
        var category = await _reposetory.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundExcaption();
        else return category;
    }

    public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
    {
        var category = await _reposetory.GetByIdAsync(categoryId);
        if(category is null)throw new CategoryNotFoundExcaption();

        // parse new items to category
        category.Name = dto.Name;
        category.Description = dto.Description;

        if(dto.Image is not null)
        {
            //delete old image
            var deleteResult = await _fileService.DeleteImageAsync(category.ImagePath);
            if(deleteResult is false ) throw new ImageNotFoundException();

            // upload new image
            string newImagePath = await _fileService.UploadImageAsync(dto.Image);

            // parse new path to category
            category.ImagePath = newImagePath;
        }
        //else category old image have to save

        category.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _reposetory.UpdateAsync(categoryId, category);
        return dbResult > 0;

    }
}
