using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCoursesApi.Dto;
using OnlineCoursesApi.Interfaces;
using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController: ControllerBase
    {
       private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SendMessage([FromBody] ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             var contactModel = new Contact {
                Name = contactDto.name,
                Email = contactDto.email,
                Message = contactDto.message,
            };

            await _contactRepository.SaveMessageAsync(contactModel);

            return Ok(contactModel);
        }
    }
}