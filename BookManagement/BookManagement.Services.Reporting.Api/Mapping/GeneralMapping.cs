using AutoMapper;
using BookManagement.Services.Reporting.Core.DTO;
using BookManagement.Services.Reporting.Core.Models;

namespace BookManagement.Services.Reporting.Api.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Reports, ReportDto>().ReverseMap();
            CreateMap<Reports, ReportDataDto>().ReverseMap();
        }
    }
}
