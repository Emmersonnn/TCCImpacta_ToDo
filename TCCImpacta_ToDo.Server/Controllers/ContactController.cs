using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TCCImpacta_ToDo.Application.Details;
using TCCImpacta_ToDo.Application.Details.Repository;
using TCCImpacta_ToDo.EntityFramework.Data.Models;

namespace TCCImpacta_ToDo.Application.Controllers;

[ApiController]
public class ContactController : ControllerBase
{
    private readonly IRepository<ContactUser> _contactRepository;

    private static readonly string apiKey = "mlsn.06e79489d44c1d16a4261817cd7982795d64ae604c0f71baae78098d05a84337";
    private static readonly string apiUrl = "https://api.mailersend.com/v1/email";

    public ContactController(IRepository<ContactUser> contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpPost]
    [Route("contact")]
    public async Task<IActionResult> Contact(ContactDto input)
    {
        if (input.EmailAddress is null || input.EmailAddress == string.Empty)
            return BadRequest(new { message = "Email inválido ou nulo." });

        var emailSend = await SendEmail(input.EmailAddress, input.Name);
        if (emailSend)
        {
            await SaveContact(input);
            return Ok(new { message = "Seu contato foi salvo com sucesso!" });
        }
        else
            return BadRequest(new { message = "Não foi possível fazer o contato." });
    }

    private async Task SaveContact(ContactDto input)
    {
        var newContact = new ContactUser()
        {
            Name = input.Name,
            EmailAddress = input.EmailAddress,
            Message = input.Message
        };

        await _contactRepository.AddAsync(newContact);
        await _contactRepository.SaveChangesAsync();
    }

    private static async Task<bool> SendEmail(string toEmail, string userName)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var emailContent = new
        {
            from = new { email = "MS_QQMDYe@trial-v69oxl5n3ozl785k.mlsender.net" },
            to = new[] { new { email = toEmail } },
            subject = "Obrigado por entrar em contato!",
            text = $@"
               Oi, {userName}!
                Obrigado por entrar em contato com a gente! Sua mensagem foi recebida e nossa equipe já está cuidando dela com carinho. Em breve, vamos te dar um retorno completo e ajudar no que for necessário.
                Se tiver algo mais urgente ou alguma dúvida, é só nos chamar. Estamos à disposição!
                Um abraço!"
        };

        var jsonContent = JsonConvert.SerializeObject(emailContent);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
    }
}
