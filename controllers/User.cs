using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGE_INICIO_C__API.data;
using SIGE_INICIO_C__API.Dtos.User;
using SIGE_INICIO_C__API.Filters;
using SIGE_INICIO_C__API.Mappers;
using SIGE_INICIO_C__API.models;


namespace SIGE_INICIO_C__API.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DBContext _context;

        public UserController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        // [User_ValidateCreateUserFilter]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto userDto)
        {
            var user = userDto.ToUserFromCreateDTO();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user.ToUserDto());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserRequestDto updateDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            user.UserId = updateDto.UserId;
            user.Name = updateDto.Name;
            user.LastName = updateDto.LastName;
            user.Privileges = updateDto.Privileges;
            user.Password = updateDto.Password;
            user.Areas = updateDto.Areas;

            await _context.SaveChangesAsync();
            return Ok(user.ToUserDto());
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {

            var users = await _context.Users.ToListAsync();
            var usersDto = users.Select(user => user.ToUserDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var DBUser = await _context.Users.FindAsync(id);
            if (DBUser == null)
            {
                return NotFound();
            }

            return Ok(DBUser.ToUserDto());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}