using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCImpacta_ToDo.EntityFramework.Data.Models;

[Table("ShopList")]
public class ShopList : AuditableEntity
{
    [Required]
    [StringLength(50)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public int Quantidade { get; set; }

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User? Usuario { get; set; }
}
