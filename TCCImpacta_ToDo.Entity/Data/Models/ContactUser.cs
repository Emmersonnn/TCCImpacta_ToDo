using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCImpacta_ToDo.EntityFramework.Data.Models;

[Table("ContactUser")]
public class ContactUser : AuditableEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string EmailAddress { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string Message { get; set; } = string.Empty;
}
