using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TCCImpacta_ToDo.EntityFramework.Data.Models;

[Table("Usuarios")]
public class User : AuditableEntity
{
    [Required]
    [StringLength(50)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string Senha { get; set; } = string.Empty;
}
