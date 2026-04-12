using CLEAN.APPLICATION;
using CLEAN.APPLICATION.Interfaces;
using CLEAN.DOMAIN.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CLEAN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
            => _userService = userService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user is null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto request)
        {
            var userCreated = await _userService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = userCreated.Id },
                userCreated
            );
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto request)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user is null) return NotFound();

            await _userService.UpdateAsync(id, request);
            return Ok(user);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user is null) return NotFound();

            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}