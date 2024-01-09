using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("participants")]
    public class Participant
    {
        [ForeignKey("CalendarEvent")]
        [Required(ErrorMessage = "CalendarEventId is required")]
        [Column("calendarEventId", TypeName = "uuid")]
        public Guid CalendarEventId { get; set; }

        [ForeignKey("User")]
        [Required(ErrorMessage = "UserId is required")]
        [Column("userId", TypeName = "uuid")]
        public Guid UserId { get; set; }

        [Column("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
