    using EnterComputers.DataAcces.Interfaces.Categories;
using EnterComputers.DataAcces.Repositories.Categories;
using EnterComputers.Domain.Entities.Categories;
using EnterComputers.Service.Common.Helpers;
using EnterComputers.Service.Dtos.Categories;
using EnterComputers.Service.Interfaces.Categories;
using Microsoft.AspNetCore.Mvc;

namespace EnterComputers.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategotiesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategotiesController(ICategoryService service)
    {
        this._service = service;
    }
    [HttpGet]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));
}
