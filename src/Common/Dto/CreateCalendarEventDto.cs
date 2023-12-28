using API.Common.Interfaces;
using API.Models;

namespace API.Common.Dto;

public class CreateCalendarEventDto : ICreateCalendarEventDto
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public CalendarEvent CalendarEvent { get; set; }
    public List<Participant>? Participants { get; set; }
};
