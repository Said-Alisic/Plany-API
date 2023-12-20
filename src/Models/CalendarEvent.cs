using System.ComponentModel.DataAnnotations;
using API.Common.Enums;

namespace API.Models
{
    public class CalendarEvent
    {
        [Key]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Time of Day is required")]
        public string TimeOfDay { get; set; } = "";

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
