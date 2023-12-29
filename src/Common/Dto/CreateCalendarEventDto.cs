using API.Common.Interfaces;
using API.Models;

namespace API.Common.Dto;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class CreateCalendarEventDto : ICreateCalendarEventDto
{
    public CalendarEvent CalendarEvent { get; set; }
    public List<Participant>? Participants { get; set; }
};
