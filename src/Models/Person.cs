using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        [Column("id", TypeName = "uuid")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        [Column("firstname", TypeName = "varchar(255)")]
        public string Firstname { get; set; } = "";

        [Required(ErrorMessage = "Lastname is required")]
        [Column("lastname", TypeName = "varchar(255)")]
        public string Lastname { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        [Column("email", TypeName = "varchar(255)")]
        public string Email { get; set; } = "";
    }
}
