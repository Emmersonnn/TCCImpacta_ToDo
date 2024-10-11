using System.ComponentModel.DataAnnotations;

namespace TCCImpacta_ToDo.Application.Details;

public class ShopListDetail
{
    [Required]
    [StringLength(50)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public int Quantidade { get; set; }

    public string Usuario { get; set; } = string.Empty;
}
