using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace template_dotnet.Models
{
    public abstract class AbstractUpperEntity: AbstractBaseEntity
    {

        // Date and time the entity was created.
        [Required]
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Date and time the entity was last updated.
        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; }

        // Flag to indicate whether the entity is delete.
        [Required]
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
