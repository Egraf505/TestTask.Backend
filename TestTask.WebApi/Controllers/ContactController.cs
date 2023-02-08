using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestTask.Aplication.Common.DTO;
using TestTask.Aplication.Interfaces;
using TestTask.Domain;
using TestTask.Persistence;

namespace TestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactDbContext _dbContext;
        private readonly CancellationTokenSource _cancellationToken;
        public ContactController(IContactDbContext dbContext)
        {
            _dbContext = dbContext;
            _cancellationToken = new CancellationTokenSource();
        }

        [HttpPost]
        public async Task<IActionResult> PostContactAsync([FromBody]ContactDTO contactDTO)
        {
            if (contactDTO == null)
                return BadRequest("The request was empty");

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(contactDTO);
            if (!Validator.TryValidateObject(contactDTO,validationContext,validationResults,true))
            {
                return BadRequest(String.Join('\n', validationResults));
            }

            TypeMessage? typeMessage = await _dbContext.TypeMessages.FirstOrDefaultAsync(type => type.Title == contactDTO.TypeMessage);
            
            if (typeMessage == null)
            {
                return NotFound("Type message not Found");
            }

            Contact? contact = await _dbContext.Contacts.FirstOrDefaultAsync(contact => contact.Email == contactDTO.Email && contact.Phone == contactDTO.Phone);

            if (contact == null)
            {
               contact = new Contact() { Name = contactDTO.Name, Email = contactDTO.Email, Phone = contactDTO.Phone};
               await _dbContext.Contacts.AddAsync(contact);
            }

            Message message = new Message() { Title = contactDTO.Message, TypeMessage = typeMessage, Contact = contact };
            await _dbContext.Messages.AddAsync(message);

            await _dbContext.SaveChangesAsync(_cancellationToken.Token);

            return Created(contact.Id.ToString(),contact);
        }
    }
}
