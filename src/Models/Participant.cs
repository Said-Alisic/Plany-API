using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    [Table("participant")]
    [Keyless]
    public class Participant
    {
        [ForeignKey("CalendarEvent")]
        [Required(ErrorMessage = "CalendarEventId is required")]
        [Column("calendarEventId", TypeName = "uuid")]
        public Guid CalendarEventId { get; set; }

        [ForeignKey("Person")]
        [Required(ErrorMessage = "PersonId is required")]
        [Column("personId", TypeName = "uuid")]
        public Guid PersonId { get; set; }
    }
}
