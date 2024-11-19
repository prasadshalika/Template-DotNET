using System.ComponentModel.DataAnnotations;

namespace template_dotnet.DTOs
{
    public class CreateUserRequestDto
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Password { get; set; } = string.Empty;

        [StringLength(200)]
        public string RestoredPassword { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public long RoleId { get; set; } // ID of the role assigned to the user
    }
}
