using API.Common.Interfaces;
using API.Models;

namespace API.Common.Dto;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class GetCalendarEventResponseDto : IGetCalendarEventResponseDto
{
    public Guid Id { get; set; }

    public DateTime DateAndTime { get; set; }

    public string Title { get; set; }

    public string Location { get; set; }

    public string Status { get; set; }

    public List<User>? EventParticipants { get; set; }
};
