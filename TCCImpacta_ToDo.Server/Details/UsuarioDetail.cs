using System.ComponentModel.DataAnnotations;

namespace TCCImpacta_ToDo.Application.Details
{
    public class UsuarioDetail
    {
        [MaxLength(50)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Senha { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ConfirmaSenha { get; set; } = string.Empty;
    }
}
