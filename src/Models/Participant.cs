using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Participant
    {
        [ForeignKey("CalendarEvent")]
        [Required(ErrorMessage = "Participant Id is required")]
        public int CalendarEventId { get; set; }

        [ForeignKey("Participant")]
        [Required(ErrorMessage = "Participant Id is required")]
        public int ParticipantId { get; set; }
    }
}
