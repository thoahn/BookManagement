using BookManagement.Services.Contact.Core.DTO;
using BookManagement.Services.Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Services.Contact.Core.Services
{
    public interface IPersonContactService : IService<PersonContacts>
    {
        Task<IEnumerable<ContactTypeDto>> GetContactTypeList();

        Task<IEnumerable<PersonContactDto>> GetAllByPersonId(Guid id);

        Task<PersonContactDto> AddorUpdateAsync(PersonContactDto contact);

        Task<bool> DeleteAsync(Guid id);


    }
}
