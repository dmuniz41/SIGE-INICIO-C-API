using Microsoft.AspNetCore.Mvc;
using SIGE_INICIO_C__API.data;
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
        public IActionResult CreateUser([FromBody] User user)
        {

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {

            var users = _context.Users.ToList().Select(user => user.ToUserDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<List<User>> GetOneUser(int id)
        {
            var DBUser = _context.Users.Find(id);
            if (DBUser == null)
            {
                return NotFound();
            }

            return Ok(DBUser);
        }
    }
}