using BookManagement.Web.Models;
using BookManagement.Web.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetPersonList()
        {
            var result = await _personService.GetPersonList();

            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpPost]
        public async Task<IActionResult> GetPersonContacts([FromBody] RequestModel model)
        {
            var result = await _personService.GetPersonContactsByPersonId(model.id);

            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpPost]
        public async Task<IActionResult> GetContactTypes()
        {
            var result = await _personService.GetContactTypes();

            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpPost]
        public async Task<IActionResult> SavePerson([FromBody] PersonDto model)
        {
            var result = await _personService.SavePerson(model);
            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpPost]
        public async Task<IActionResult> DeletePerson([FromBody] RequestModel model)
        {
            var result = await _personService.DeletePerson(model.id);
            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpPost]
        public async Task<IActionResult> SaveContact([FromBody] PersonContactDto model)
        {
            var result = await _personService.SavePersonContact(model);
            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpPost]
        public async Task<IActionResult> DeletePersonContact([FromBody] RequestModel model)
        {
            var result = await _personService.DeletePersonContact(model.id);
            return new ContentResult() { Content = result, ContentType = "application/json" };
        }



    }
}
