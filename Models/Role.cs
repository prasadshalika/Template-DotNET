using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace template_dotnet.Models
{
    public class Role : AbstractUpperEntity
    {
        [Required]
        [StringLength(50)]
        [Column("name")]
        public required string Name { get; set; }

        [StringLength(200)]
        [Column("description")]
        public string? Description { get; set; }

        // Navigation property for the users in this role
        public ICollection<UserAccount> Users { get; set; } = new List<UserAccount>();
    }

}
