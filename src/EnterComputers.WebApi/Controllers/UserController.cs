using EnterComputers.DataAcces.Interfaces.Users;
using EnterComputers.DataAcces.Utils;
using EnterComputers.Service.Dtos.Users;
using EnterComputers.Service.Interfaces.Users;
using EnterComputers.Service.Validators.Dtos.Users;
using Microsoft.AspNetCore.Mvc;

namespace EnterComputers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        IUserService _userService;
        private IWebHostEnvironment _env;
        private readonly int maxPageSize = 30;
        public UserController(IUserService userService, IUserRepository userRepository)
        {
            this._userService = userService;
            this._userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _userService.GetAllAsync(new PaginationParams(page, maxPageSize)));

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _userService.CountAsync());

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] UserCreateDto userCreateDto)
        {
            var createValidator = new UserCreateValidator();
            var result = createValidator.Validate(userCreateDto);
            if (result.IsValid) return Ok(await _userService.CreateAsync(userCreateDto));
            else return BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await _userService.DeleteAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] UserUpdateDto userUpdateDto)
        {
            var updateValidator = new UserUpdateValidator();
            var vrResult = updateValidator.Validate(userUpdateDto);
            if (vrResult.IsValid) return Ok(await _userService.UpdateAsync(id, userUpdateDto));
            else return BadRequest(vrResult.Errors);
        }
    }
}
