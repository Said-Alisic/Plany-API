using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly ApiDbContext _apiDbContext;

        public PersonsController(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;

            _apiDbContext.Database.EnsureCreated();
        }

        [HttpGet, Route(""),]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons([FromQuery] string? email)
        {
            IQueryable<Person> query = _apiDbContext.Persons;

            if (Request.Query.ContainsKey("email"))
            {
                query = query.Where(item => item.Email.Equals(email));
            }

            Person[] persons = await query.ToArrayAsync() ?? Array.Empty<Person>();

            if (persons == null || persons.Length == 0)
            {
                return NotFound();
            }

            return Ok(persons);
        }
    }
}
