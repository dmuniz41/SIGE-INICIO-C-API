using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGE_INICIO_C__API.data;
using SIGE_INICIO_C__API.Dtos.User;
using SIGE_INICIO_C__API.Filters;
using SIGE_INICIO_C__API.Interfaces;
using SIGE_INICIO_C__API.Mappers;
using SIGE_INICIO_C__API.models;


namespace SIGE_INICIO_C__API.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IUserRepository _userRepository;

        public UserController(DBContext context, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto userDto)
        {
            var user = userDto.ToUserFromCreateDTO();
            await _userRepository.CreateAsync(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user.ToUserDto());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserRequestDto updateDto)
        {
            var user = await _userRepository.UpdateAsync(id, updateDto);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var usersDto = users.Select(user => user.ToUserDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _userRepository.DeleteAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}