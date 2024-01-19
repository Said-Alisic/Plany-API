using API.Common.Dto;
using API.Models;

namespace API.Common.Interfaces;

public interface ICalendarEventsService
{
    Task<CalendarEvent> GetCalendarEventAsync(Guid calendarEventId);
    Task<IEnumerable<CalendarEvent>> GetCalendarEventsAsync(DateTime? date);
    Task<IEnumerable<User>?> GetCalendarEventParticipantsAsync(Guid calendarEventId);
    Task<CreateCalendarEventDto> CreateCalendarEventAsync(
        CalendarEvent calendarEvent,
        string[] userIds
    );
    Task DeleteCalendarEventAsync(CalendarEvent calendarEvent);
}
