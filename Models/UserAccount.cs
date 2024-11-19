using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace template_dotnet.Models
{
    public class UserAccount : AbstractUpperEntity
    {
        [Required]
        [StringLength(20)]
        [Column("username")]
        public required string UserName { get; set; }

        [Required]
        [JsonIgnore]
        [StringLength(200)]
        [Column("hashed_password")]
        public required string Password { get; set; }

        [JsonIgnore]
        [StringLength(200)]
        [Column("restored_password")]
        public required string RestoredPassword { get; set; }

        [Required]
        [StringLength(50)]
        [Column("firstname")]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("lastname")]
        public required string LastName { get; set; }

        // Foreign key for Role
        [Required]
        [Column("role_id")]
        public long RoleId { get; set; }

        // Navigation property for the Role
        public required Role Role { get; set; }
    }
}
