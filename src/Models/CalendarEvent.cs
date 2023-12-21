using System.ComponentModel.DataAnnotations;
using API.Common.Enums;

namespace API.Models
{
    public class CalendarEvent
    {
        [Key]
        public string? Id { get; set; }

        [Required(ErrorMessage = "DateAndTime is required")]
        public DateTime DateAndTime { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = "";

        [Required(ErrorMessage = "Status is required")]
        [EnumDataType(
            typeof(EventStatus),
            ErrorMessage = "Status value must be one of ACTIVE, CANCELED or COMPLETED!"
        )]
        public EventStatus Status { get; set; }
    }
}
