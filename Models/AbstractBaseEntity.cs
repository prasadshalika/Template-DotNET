using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace template_dotnet.Models
{
    public abstract class AbstractBaseEntity
    {
        // A unique id for the entity.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long Id { get; set; }
    }
}
