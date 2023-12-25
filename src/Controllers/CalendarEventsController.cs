using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/calendar-events")]
    [ApiController]
    public class CalendarEventsController : Controller
    {
        private readonly ApiDbContext _apiDbContext;

        public CalendarEventsController(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;

            _apiDbContext.Database.EnsureCreated();
        }

        [HttpGet, Route(""),]
        public async Task<ActionResult<IEnumerable<CalendarEvent>>> GetCalendarEvents(
            [FromQuery] DateTime? date
        )
        {
            IQueryable<CalendarEvent> query = _apiDbContext.CalendarEvents;

            if (Request.Query.ContainsKey("date"))
            {
                query = query.Where(item => item.DateAndTime.Date.Equals(date));
            }

            CalendarEvent[] calendarEvents =
                await query.ToArrayAsync() ?? Array.Empty<CalendarEvent>();

            if (calendarEvents == null || calendarEvents.Length == 0)
            {
                return NotFound();
            }

            return Ok(calendarEvents);
        }
    }
}
