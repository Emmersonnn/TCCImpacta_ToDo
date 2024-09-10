using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TCCImpacta_ToDo.EntityFramework.Data.Models;

public abstract class AuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public DateTime DataDeCriacao { get; set; } = DateTime.UtcNow;
}
