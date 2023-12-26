using API.Common.Dto;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

#pragma warning disable CS8601 // Possible null reference assignment.

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

        // SEPARATOR: GET Endpoints
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

        // SEPARATOR: POST Endpoints
        [HttpPost, Route("")]
        public async Task<ActionResult<CreateCalendarEventDto>> CreateCalendarEvent(
            [FromBody] CalendarEvent calendarEvent,
            [FromQuery(Name = "personIds[]")] string[] personIds
        )
        {
            if (calendarEvent == null)
            {
                return BadRequest("Invalid data provided!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data provided!");
            }

            EntityEntry createdCalendarEvent = await _apiDbContext.CalendarEvents.AddAsync(
                calendarEvent
            );

            // Define response object
            CreateCalendarEventDto response = new CreateCalendarEventDto
            {
                CalendarEvent = createdCalendarEvent.Entity as CalendarEvent
            };

            if (personIds != null && personIds.Any())
            {
                List<Participant> participants = personIds
                    .Distinct()
                    .Select(
                        personId =>
                            new Participant
                            {
                                CalendarEventId = calendarEvent.Id,
                                PersonId = Guid.Parse(personId)
                            }
                    )
                    .ToList();

                await _apiDbContext.Participants.AddRangeAsync(participants);

                // Add participants to response object if any
                response.Participants = participants;
            }

            await _apiDbContext.SaveChangesAsync();

            return Created("api/calendar-events", response);
        }
    }
}
