using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using TCCImpacta_ToDo.Application.Details;
using TCCImpacta_ToDo.Application.Details.Repository;
using TCCImpacta_ToDo.EntityFramework.Data.Models;

namespace TCCImpacta_ToDo.Application.Controllers;

public class AccountController : ControllerBase
{
    private readonly IRepository<User> _userRepository;

    public AccountController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioDetail input)
    {
        var usuario = await _userRepository.FirstOrDefaultAsync(x => x.Nome == input.Nome || x.Email == input.Email);

        if (usuario is null)
            return BadRequest(new { message = "Usuário ou senha inválidos." });

        var senhaHash = HashPassword(input.Senha);

        if (usuario.Senha != senhaHash)
            return BadRequest(new { message = "Usuário ou senha inválidos." });

        return Ok(new { message = "Usuário logado com sucesso." });
    }

    [HttpPost]
    [Route("reset")]
    public async Task<IActionResult> ResetPassword([FromBody] UsuarioDetail input)
    {
        var userExist = await Login(input);

        if (userExist is not null)
        {
            await UpdatePassword(input);
            return Ok(new { message = "Senha alterada com sucesso." });
        }

        return BadRequest(new { message = "Usuário ou senha inválidos." });
    }

    private async Task UpdatePassword(UsuarioDetail input)
    {
        var usuario = await _userRepository.FirstOrDefaultAsync(x => x.Email == input.Email);

        var senhaHash = HashPassword(input.NovaSenha);
        usuario.Senha = senhaHash;

        await _userRepository.UpdateAsync(usuario);
        await _userRepository.SaveChangesAsync();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] UsuarioDetail input)
    {
        bool senhaIgual = input.ConfirmaSenha == input.Senha;

        if (!senhaIgual)
            return BadRequest(new { message = "A senha não coincide com a outra." });

        var usuarioExiste = await _userRepository.FirstOrDefaultAsync(x => x.Email == input.Email);

        if (usuarioExiste is null)
        {
            var senhaHash = HashPassword(input.Senha);

            var novoUsuario = new User
            {
                Nome = input.Nome,
                Senha = senhaHash,
                Email = input.Email
            };

            await _userRepository.AddAsync(novoUsuario);
            await _userRepository.SaveChangesAsync();

            return Ok(new { message = "O registro foi feito com sucesso!" });
        }
        else
            return BadRequest(new { message = "O email já está cadastrado." });
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
