using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ApiDbContext _apiDbContext;

        public UsersController(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;

            _apiDbContext.Database.EnsureCreated();
        }

        // TODO: Add regex matching for the `email` query param
        [HttpGet, Route(""),]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers([FromQuery] string? email)
        {
            IQueryable<User> query = _apiDbContext.Users;

            if (Request.Query.ContainsKey("email"))
            {
                query = query.Where(item => item.Email.Equals(email));
            }

            User[] Users = await query.ToArrayAsync() ?? Array.Empty<User>();

            if (Users == null || Users.Length == 0)
            {
                return NotFound();
            }

            return Ok(Users);
        }
    }
}
