using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Person
    {
        [Key]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public string firstname { get; set; } = "";

        [Required(ErrorMessage = "Lastname is required")]
        public string lastname { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; } = "";
    }
}
