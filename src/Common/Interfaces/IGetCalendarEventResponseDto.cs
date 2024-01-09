using API.Models;

namespace API.Common.Interfaces;

public interface IGetCalendarEventResponseDto
{
    public Guid Id { get; set; }
    public DateTime DateAndTime { get; set; }
    public string Title { get; }

    public string Location { get; set; }
    public string Status { get; set; }

    List<User>? EventParticipants { get; set; }
}
