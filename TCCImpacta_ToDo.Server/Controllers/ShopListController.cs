using Microsoft.AspNetCore.Mvc;
using TCCImpacta_ToDo.Application.Details;
using TCCImpacta_ToDo.Application.Details.Repository;
using TCCImpacta_ToDo.EntityFramework.Data.Models;

namespace TCCImpacta_ToDo.Application.Controllers;

public class ShopListController : ControllerBase
{
    private readonly IRepository<ShopList> _shopListRepository;
    private readonly IRepository<User> _userRepository;

    public ShopListController(IRepository<ShopList> shopListRepository, IRepository<User> userRepository)
    {
        _shopListRepository = shopListRepository;
        _userRepository = userRepository;
    }

    [HttpPost]
    [Route("shop")]
    public async Task<IActionResult> AddItem([FromBody] ShopListDetail input)
    {
        try
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Nome == input.Usuario);

            var addItem = new ShopList()
            {
                Nome = input.Nome,
                Quantidade = input.Quantidade,
                UserId = user.Id
            };

            await _shopListRepository.AddAsync(addItem);
            await _shopListRepository.SaveChangesAsync();

            return Ok(new { message = "Item salvo com sucesso!" });
        }
        catch
        {
            return BadRequest(new { message = "Não foi possível salvar o item." });
        }
    }

    [HttpPost]
    [Route("shop/delete")]
    public async Task<IActionResult> RemoveItem([FromBody] ShopListDetail input)
    {
        try
        {
            var item = await _shopListRepository.FirstOrDefaultAsync(x => x.Nome == input.Nome && x.Quantidade == input.Quantidade);

            await _shopListRepository.DeleteAsync(item.Id);
            await _shopListRepository.SaveChangesAsync();

            return Ok(new { message = "Item deletado com sucesso!" });
        }
        catch
        {
            return BadRequest(new { message = "Não foi possível deletar o item." });
        }
    }
}
