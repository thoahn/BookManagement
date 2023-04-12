using AutoMapper;
using BookManagement.Services.Contact.Core.DTO;
using BookManagement.Services.Contact.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Services.Contact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonContactController : ControllerBase
    {
        private readonly IPersonContactService _personContactService;
        private readonly IMapper _mapper;

        public PersonContactController(IMapper mapper, IPersonContactService personContactService)
        {
            _personContactService = personContactService;
            _mapper = mapper;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ContactTypeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getContactTypes")]
        public async Task<IActionResult> GetContactTypeList()
        {
            var result = await _personContactService.GetContactTypeList();

            return Ok(result);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonContactDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet]
        [Route("/api/[controller]/getAllByPersonId/{id}")]
        public async Task<IActionResult> GetByPersonId(Guid id)
        {
            var result = await _personContactService.GetAllByPersonId(id);

            return Ok(result);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonContactDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("savePersonContact")]
        public async Task<IActionResult> SavePersonContact([FromBody] PersonContactDto model)
        {
            var result = await _personContactService.AddorUpdateAsync(model);

            return Ok(result);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        [Route("/api/[controller]/deletePersonContact/{id}")]
        public async Task<IActionResult> DeletePersonContact(Guid id)
        {
            var entity = await _personContactService.DeleteAsync(id);

            if (entity == false)
                return BadRequest("Kayıt bulunamadı");

            return Ok(true);
        }

    }
}
