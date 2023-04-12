using BookManagement.Web.Models;

namespace BookManagement.Web.Services.Abstract
{
    public interface IPersonService
    {
        Task<string> GetPerson();

        Task<string> GetPersonList();

        Task<string> GetPersonContactsByPersonId(Guid id);

        Task<string> GetContactTypes();

        Task<string> SavePerson(PersonDto model);

        Task<string> DeletePerson(Guid id);

        Task<string> SavePersonContact(PersonContactDto model);

        Task<string> DeletePersonContact(Guid id);

    }
}
