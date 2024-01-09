using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Common.Enums;

namespace API.Models
{
    [Table("users")]
    public class User
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

        [Required(ErrorMessage = "Password is required")]
        [Column("password", TypeName = "varchar(100)")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Theme is required")]
        [EnumDataType(
            typeof(Theme),
            ErrorMessage = "Status value must be one of SYSTEM, DARK, or LIGHT!"
        )]
        [Column("theme", TypeName = "themeEnum")]
        public string Theme { get; set; } = "SYSTEM";

        [Required(ErrorMessage = "NotificationsEnabled is required")]
        [Column("notificationsEnabled")]
        public bool NotificationsEnabled { get; set; } = true;

        [Column("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
