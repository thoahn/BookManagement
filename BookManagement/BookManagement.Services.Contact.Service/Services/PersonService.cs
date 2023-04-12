using AutoMapper;
using BookManagement.Services.Contact.Core.DTO;
using BookManagement.Services.Contact.Core.Models;
using BookManagement.Services.Contact.Core.Repositories;
using BookManagement.Services.Contact.Core.Services;
using BookManagement.Services.Contact.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Services.Contact.Service.Services
{
    public class PersonService : Service<Persons>, IPersonService
    {

        private readonly IMapper _mapper;

        public PersonService(IMapper mapper, IUnitOfWork unitOfWork, IRepository<Persons> repository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
        }

        public async Task<PersonDto> AddorUpdateAsync(PersonDto person)
        {
            var entity = _mapper.Map<Persons>(person);
            if (person.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
                await _unitOfWork.Persons.AddAsync(entity);
            }
            else
            {
                entity = _unitOfWork.Persons.Update(entity);
            }
            await _unitOfWork.CommitAsync();

            return _mapper.Map<PersonDto>(entity);

        }

        public async Task<IEnumerable<PersonDto>> GetListAsync()
        {
            var result = await _unitOfWork.Persons.GetAllAsync();

            return _mapper.Map<List<PersonDto>>(result);
        }

        public async Task<IEnumerable<ReportDataDto>> GetReportData()
        {
            return await _unitOfWork.Persons.GetReportData();
        }
    }
}
