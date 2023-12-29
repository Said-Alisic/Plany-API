using API.Common.Dto;
using API.Common.Helpers.AutoMapper;
using API.Data;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8600, CS8602 // Converting null literal or possible null value to non-nullable type.

namespace API.Controllers
{
    [Route("api/calendar-events")]
    [ApiController]
    public class CalendarEventsController : Controller
    {
        private readonly ApiDbContext _apiDbContext;
        private readonly Mapper _mapper;

        public CalendarEventsController(ApiDbContext apiDbContext)
        {
            // Setup db connection
            _apiDbContext = apiDbContext;

            _apiDbContext.Database.EnsureCreated();

            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddProfile<CalendarEventMapperProfile>()
            );

            _mapper = new Mapper(config);
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

        [HttpGet, Route("{id}")]
        public async Task<
            ActionResult<GetCalendarEventResponseDto>
        > GetCalendarEventWithParticipantsInformation(
            [FromRoute] string id,
            [FromQuery] bool omitEventParticipants = false
        )
        {
            // Checks if the `id` is a GUID string, if successful, parses it and assigns it to a new variable
            if (!Guid.TryParse(id, out Guid calendarEventId))
            {
                return BadRequest("Invalid GUID id format provided.");
            }

            CalendarEvent calendarEvent =
                await _apiDbContext.CalendarEvents.FindAsync(calendarEventId) ?? null;

            if (calendarEvent == null)
            {
                return NotFound();
            }

            GetCalendarEventResponseDto response = new GetCalendarEventResponseDto();

            if (!omitEventParticipants)
            {
                List<Guid> participantsPersonIds =
                    await _apiDbContext
                        .Participants.Where(item => item.CalendarEventId.Equals(calendarEventId))
                        .Select(item => item.PersonId)
                        .ToListAsync() ?? null;

                // If participants' personIds were found, search database for those persons and add it to the response
                if (participantsPersonIds != null && participantsPersonIds.Any())
                {
                    List<Person> eventParticipants =
                        await _apiDbContext
                            .Persons.Where(item => participantsPersonIds.Contains(item.Id))
                            .ToListAsync() ?? null;

                    response = _mapper.Map<GetCalendarEventResponseDto>(calendarEvent);
                    response.EventParticipants = eventParticipants;

                    return Ok(response);
                }
            }

            response = _mapper.Map<GetCalendarEventResponseDto>(calendarEvent);

            return Ok(response);
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
                return BadRequest("Invalid data provided.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data provided.");
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

        // SEPARATOR: DELETE Endpoints
        [HttpDelete, Route("{id}")]
        public async Task<ActionResult> DeleteCalendarEvent([FromRoute] string id)
        {
            // Checks if the `id` is a GUID string, if successful, parses it and assigns it to a new variable
            if (!Guid.TryParse(id, out Guid calendarEventId))
            {
                return BadRequest("Invalid GUID id format provided.");
            }

            // Find CalendarEvent to delete.
            CalendarEvent existingCalendarEvent = await _apiDbContext.CalendarEvents.FindAsync(
                calendarEventId
            );

            if (existingCalendarEvent == null)
            {
                return NotFound("Calendar event with the given id could not be found.");
            }

            // Prepare deletion of CalendarEvent in the db
            _apiDbContext.CalendarEvents.Remove(existingCalendarEvent);

            try
            {
                // Save changes to db
                await _apiDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new ApplicationException(
                    "An error occured while saving changes to the database.",
                    e
                );
            }

            return NoContent();
        }
    }
}
