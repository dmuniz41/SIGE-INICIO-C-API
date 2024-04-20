using Microsoft.AspNetCore.Mvc;
using SIGE_INICIO_C__API.models;

namespace SIGE_INICIO_C__API.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {

            var users = new List<User>{
                new() {
                    Name = "Daniel",
                    UserId= "dmuniz",
                    LastName= "Muniz",
                    Password="1234",
                    Privileges=[],
                    Areas=[]
                }
            };

            return Ok(users);
        }
    }
}