using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Common.Enums;

#pragma warning disable CS8618

namespace API.Models
{
    [Table("calendarEvent")]
    public class CalendarEvent
    {
        [Key]
        [Column("id", TypeName = "uuid")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "DateAndTime is required")]
        [Column("dateAndTime", TypeName = "timestamp")]
        public DateTime DateAndTime { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Column("title", TypeName = "varchar(255)")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Location is required")]
        [Column("location", TypeName = "varchar(255)")]
        public string Location { get; set; } = "";

        // TODO: Figure out how to implement the EventStatus enum as a string value enum
        // TODO: Possible Solution -> https://josipmisko.com/posts/string-enums-in-c-sharp-everything-you-need-to-know#custom-enumeration-class
        [Required(ErrorMessage = "Status is required")]
        [EnumDataType(
            typeof(EventStatus),
            ErrorMessage = "Status value must be one of ACTIVE, CANCELED, or COMPLETED!"
        )]
        [Column("status", TypeName = "varchar(50)")]
        public string Status { get; set; }
    }
}
