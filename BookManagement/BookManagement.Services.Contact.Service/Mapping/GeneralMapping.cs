using AutoMapper;
using BookManagement.Services.Contact.Core.DTO;
using BookManagement.Services.Contact.Core.Models;

namespace BookManagement.Services.Contact.Service.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Persons, PersonDto>().ReverseMap();

            CreateMap<PersonContacts, PersonContactDto>().ReverseMap();

            CreateMap<ContactTypes, ContactTypeDto>().ReverseMap();

        }
    }
}
