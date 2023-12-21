using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Participant
    {
        [ForeignKey("CalendarEvent")]
        [Required(ErrorMessage = "CalendarEvent Id is required")]
        public string CalendarEventId { get; set; }

        [ForeignKey("Person")]
        [Required(ErrorMessage = "Person Id is required")]
        public string PersonId { get; set; }
    }
}
