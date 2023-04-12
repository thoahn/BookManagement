using AutoMapper;
using BookManagement.Services.Reporting.Core.DTO;
using BookManagement.Services.Reporting.Core.Models;
using BookManagement.Services.Reporting.Core.Repositories;
using BookManagement.Services.Reporting.Core.Services;
using BookManagement.Services.Reporting.Core.UnitOfWorks;

namespace BookManagement.Services.Reporting.Service.Services
{
    public class ReportService : Service<Reports>, IReportService
    {

        private readonly IMapper _mapper;

        public ReportService(IMapper mapper, IUnitOfWork unitOfWork, IRepository<Reports> repository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
        }

        public async Task<ReportDto> AddAsync()
        {
            var entity = new Reports()
            {
                Id = Guid.NewGuid(),
                RequestDate = DateTime.Now,
                Status = "Hazırlanıyor"
            };

            await _unitOfWork.Report.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<ReportDto>(entity);
        }

        public async Task<IEnumerable<ReportDto>> GetListAsync()
        {
            var result = await _unitOfWork.Report.GetAllAsync();

            result = result.OrderByDescending(a => a.RequestDate).ToList();

            return _mapper.Map<List<ReportDto>>(result);
        }

        public async Task<bool> SaveRepotData(Guid id, string data)
        {
            var entity = await _unitOfWork.Report.GetByIdAsync(id);
            if (entity == null)
                return false;

            entity.Data = data;
            entity.Status = "Tamamlandı";

            _unitOfWork.Report.Update(entity);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<string> GetRepotData(Guid id)
        {
            var entity = await _unitOfWork.Report.GetByIdAsync(id);
            if (entity == null)
                return "[]";

            return entity.Data;
        }

    }
}
