using Microsoft.AspNetCore.Mvc;
using SIGE_INICIO_C__API.data;
using SIGE_INICIO_C__API.models;

namespace SIGE_INICIO_C__API.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(DBContext context) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateUser()
        {

            User user = new()
            {
                Name = "Daniel",
                UserId = "dmuniz",
                LastName = "Muniz",
                Password = "12345",
                Privileges = [],
                Areas = []

            };

            context.Users.Add(user);
            context.SaveChanges();

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            
            var users = from user in context.Users
                        select user;

            return Ok(users);
        }
    }
}