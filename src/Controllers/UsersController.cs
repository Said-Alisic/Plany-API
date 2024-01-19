using API.Common.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // TODO: Add regex matching for the `email` query param
        [HttpGet, Route(""),]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers([FromQuery] string? email)
        {
            IEnumerable<User> users = await _userService.GetUsersAsync(email);

            if (users == null || !users.Any())
            {
                return NotFound();
            }

            return Ok(users);
        }
    }
}
