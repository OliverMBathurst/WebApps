using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.TransferObjects;
using EntropyServer.Infrastructure.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EntropyServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntropyController : ControllerBase
    {
        private readonly ILogger<EntropyController> _logger;
        private readonly IEntropyResultService _entropyResultService;

        public EntropyController(
            ILogger<EntropyController> logger,
            IEntropyResultService entropyResultService)
        {
            _logger = logger;
            _entropyResultService = entropyResultService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEntropyResult([FromQuery] EntropyFilterDto entropyFilterDto)
        {
            var entropyType = DataMappings.ToEntropyType(entropyFilterDto.EntropyTypeID);
            if (entropyType != EntropyType.Undefined)
            {
                _logger.LogInformation($"Valid entropy type: {entropyType}, generating entropy.");

                return entropyType switch
                {
                    EntropyType.Int => GetActionResultInternal(await _entropyResultService.GetResult<int>(entropyFilterDto)),
                    _ => NotFound()
                };
            }
            else
            {
                _logger.LogError($"Invalid entropy type ID: {entropyFilterDto.EntropyTypeID}.");
                return BadRequest();
            }
        }

        private IActionResult GetActionResultInternal<T>(IEntropyResult<T> result)
        {
            if (result.Exception != null)
            {
                return StatusCode(500, result.Exception);
            }

            return Ok(result);
        }
    }
}