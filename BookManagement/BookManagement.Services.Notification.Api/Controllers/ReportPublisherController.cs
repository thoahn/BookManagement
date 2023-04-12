using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Services.Notification.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportPublisherController : ControllerBase
    {
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("publish")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}