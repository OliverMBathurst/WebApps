using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.TransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EntropyServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntropyController : ControllerBase
    {
        private readonly ILogger<EntropyController> _logger;
        private readonly IEntropyResultService _entropyResultService;
        private readonly IEntropyTypeRepository _entropyTypeRepository;

        public EntropyController(
            ILogger<EntropyController> logger,
            IEntropyResultService entropyResultService,
            IEntropyTypeRepository entropyTypeRepository)
        {
            _logger = logger;
            _entropyResultService = entropyResultService;
            _entropyTypeRepository = entropyTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEntropyResult([FromQuery] EntropyFilterDto entropyFilterDto)
        {
            if (_entropyTypeRepository.ToEntropyType(entropyFilterDto.EntropyTypeID, out var entropyType))
            {
                _logger.LogInformation($"Valid entropy type: {entropyType}, generating entropy.");

                var result = await _entropyResultService.GetResult(entropyType);
                if (result.Exception != null)
                {
                    return StatusCode(500, result.Exception);
                }

                return Ok(result);
            }
            else
            {
                _logger.LogError($"Invalid entropy type ID: {entropyFilterDto.EntropyTypeID}.");
                return BadRequest();
            }
        }
    }
}