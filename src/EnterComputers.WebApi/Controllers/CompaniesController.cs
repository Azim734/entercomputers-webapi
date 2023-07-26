using EnterComputers.DataAcces.Utils;
using EnterComputers.Service.Dtos.Companies;
using EnterComputers.Service.Interfaces.Companies;
using EnterComputers.Service.Validators.Dtos.Companies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterComputers.WebApi.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IcompanyService _service;
    private readonly int maxPageSize = 30;

    public CompaniesController(IcompanyService companyService)
    {
        this._service = companyService;
    }

    [HttpGet]

    public async Task<IActionResult> GetAllAsync(int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetByIdAsync(long companyId)
        => Ok(await _service.GetAllAsync(companyId));

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CompanyCreateDto dto)
    {
        var validator = new CompanyCreateValidator();
        var result = validator.Validate(dto);
        if(result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(long companyId, [FromForm] CompanyUpdateDto dto)
    {
        var validator = new CompanyUpdateValidation();
        var validationResult = validator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(companyId, dto));
        else return BadRequest(validationResult.Errors);      
    }
    
    [HttpDelete("{companyId}")]
    public async Task<IActionResult> DeleteAsync(long companyId)
        => Ok(await _service.DeleteAsync(companyId));
}
