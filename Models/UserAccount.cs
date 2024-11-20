using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace template_dotnet.Models
{
    public class UserAccount : AbstractUpperEntity
    {
        // EF Core requires a parameterless constructor
        public UserAccount() { }

        [Required]
        [StringLength(20)]
        [Column("username")]
        public string UserName { get; set; } = null!;

        [Required]
        [JsonIgnore]
        [StringLength(200)]
        [Column("hashed_password")]
        public string Password { get; set; } = null!;

        [JsonIgnore]
        [StringLength(200)]
        [Column("restored_password")]
        public string RestoredPassword { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Column("firstname")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Column("lastname")]
        public string LastName { get; set; } = null!;

        [Required]
        [Column("role_id")]
        public long RoleId { get; set; }

        // Navigation property for the Role
        public Role Role { get; set; } = null!;

        // Your parameterized constructor for your application logic
        public UserAccount(string userName, string password, string restoredPassword, string firstName, string lastName, Role role)
        {
            UserName = userName;
            Password = password;
            RestoredPassword = restoredPassword;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }
    }

}
