using AutoMapper;
using BookManagement.Services.Reporting.Core.DTO;
using BookManagement.Services.Reporting.Core.Services;
using BookManagement.Shared;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Services.Reporting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public ReportController(IMapper mapper
            , IReportService reportService
            , ISendEndpointProvider sendEndpointProvider)
        {
            _reportService = reportService;
            _sendEndpointProvider = sendEndpointProvider;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReportDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _reportService.GetListAsync();

            return Ok(result);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReportDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("saveReport")]
        public async Task<IActionResult> SaveReport()
        {
            var result = await _reportService.AddAsync();

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-report-service"));

            var createReportMessageCommand = new CreateReportMessageCommand();
            createReportMessageCommand.ReportId = result.Id;

            await sendEndpoint.Send(createReportMessageCommand);

            return Ok(result);

        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("saveReportData")]
        public async Task<IActionResult> SaveReportData([FromForm] string value, [FromForm] Guid id)
        {
            await _reportService.SaveRepotData(id, value);
            return Ok(true);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getReportData")]
        public async Task<IActionResult> GetReportData(Guid id)
        {
            var result = await _reportService.GetRepotData(id);

            return Ok(result);
        }

    }
}