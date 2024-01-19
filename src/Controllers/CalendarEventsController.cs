using API.Common.Dto;
using API.Common.Helpers.AutoMapper;
using API.Common.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

#pragma warning disable CS8600, CS8602 // Converting null literal or possible null value to non-nullable type.

namespace API.Controllers
{
    [Route("api/calendar-events")]
    [ApiController]
    public class CalendarEventsController : Controller
    {
        private readonly ICalendarEventsService _calendarEventsService;
        private readonly Mapper _mapper;

        public CalendarEventsController(ICalendarEventsService calendarEventsService)
        {
            // Setup db connection
            _calendarEventsService = calendarEventsService;

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
            IEnumerable<CalendarEvent> calendarEvents =
                await _calendarEventsService.GetCalendarEventsAsync(date);

            if (calendarEvents == null || !calendarEvents.Any())
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
            [FromQuery] bool shouldContainEventParticipants = true
        )
        {
            // Checks if the `id` is a GUID string, if successful, parses it and assigns it to a new variable
            if (!Guid.TryParse(id, out Guid calendarEventId))
            {
                return BadRequest("Invalid GUID id format provided.");
            }

            CalendarEvent calendarEvent = await _calendarEventsService.GetCalendarEventAsync(
                calendarEventId
            );

            if (calendarEvent == null)
            {
                return NotFound();
            }

            GetCalendarEventResponseDto response;

            if (shouldContainEventParticipants)
            {
                IEnumerable<User> eventParticipants =
                    await _calendarEventsService.GetCalendarEventParticipantsAsync(calendarEventId);

                response = _mapper.Map<GetCalendarEventResponseDto>(calendarEvent);
                response.EventParticipants = eventParticipants?.ToList();

                return Ok(response);
            }

            response = _mapper.Map<GetCalendarEventResponseDto>(calendarEvent);

            return Ok(response);
        }

        // SEPARATOR: POST Endpoints
        [HttpPost, Route("")]
        public async Task<ActionResult<CreateCalendarEventDto>> CreateCalendarEvent(
            [FromBody] CalendarEvent calendarEvent,
            [FromQuery(Name = "userIds[]")] string[] userIds
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

            // Define response object
            CreateCalendarEventDto response = await _calendarEventsService.CreateCalendarEventAsync(
                calendarEvent,
                userIds
            );

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
            CalendarEvent existingCalendarEvent =
                await _calendarEventsService.GetCalendarEventAsync(calendarEventId);

            if (existingCalendarEvent == null)
            {
                return NotFound("Calendar event with the given id could not be found.");
            }

            try
            {
                await _calendarEventsService.DeleteCalendarEventAsync(existingCalendarEvent);

                return NoContent();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message, e);
            }
        }
    }
}
