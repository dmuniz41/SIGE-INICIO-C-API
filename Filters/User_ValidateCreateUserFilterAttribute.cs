using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SIGE_INICIO_C__API.data;
using SIGE_INICIO_C__API.models;

namespace SIGE_INICIO_C__API.Filters
{
    public class User_ValidateCreateUserFilterAttribute(DBContext context) : ActionFilterAttribute
    {
        private readonly DBContext _context = context;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var user = context.ActionArguments["user"] as User;
            if (user == null)
            {
                context.ModelState.AddModelError("User", "User object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingUser = _context.Users.FirstOrDefault(x => x.Name == user.Name);
                if (existingUser != null)
                {
                    context.ModelState.AddModelError("User", "User already exist");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}