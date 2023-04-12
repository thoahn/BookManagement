using AutoMapper;
using BookManagement.Services.Contact.Core.DTO;
using BookManagement.Services.Contact.Core.Models;
using BookManagement.Services.Contact.Core.Repositories;
using BookManagement.Services.Contact.Core.Services;
using BookManagement.Services.Contact.Core.UnitOfWork;

namespace BookManagement.Services.Contact.Service.Services
{
    public class PersonContactService : Service<PersonContacts>, IPersonContactService
    {
        private readonly IMapper _mapper;

        public PersonContactService(IMapper mapper, IUnitOfWork unitOfWork, IRepository<PersonContacts> repository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonContactDto>> GetAllByPersonId(Guid id)
        {
            var result = await _unitOfWork.PersonContacts.Where(a => a.PersonId == id);
            return _mapper.Map<List<PersonContactDto>>(result);
        }

        public async Task<IEnumerable<ContactTypeDto>> GetContactTypeList()
        {
            var result = await _unitOfWork.PersonContacts.GetContactTypeList();
            return _mapper.Map<List<ContactTypeDto>>(result);
        }

        public async Task<PersonContactDto> AddorUpdateAsync(PersonContactDto contact)
        {
            var entity = _mapper.Map<PersonContacts>(contact);
            if (contact.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
                await _unitOfWork.PersonContacts.AddAsync(entity);
            }
            else
            {
                entity = _unitOfWork.PersonContacts.Update(entity);
            }

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PersonContactDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _unitOfWork.PersonContacts.GetByIdAsync(id);
            if (entity != null)
                _unitOfWork.PersonContacts.Remove(entity);
            else
                return false;

            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
