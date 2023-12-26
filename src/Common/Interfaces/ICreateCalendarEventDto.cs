using API.Models;

namespace API.Common.Interfaces;

public interface ICreateCalendarEventDto
{
    CalendarEvent CalendarEvent { get; set; }
    List<Participant>? Participants { get; set; }
}
