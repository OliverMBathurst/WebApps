using System.Threading.Tasks;
using EntropyServer.Domain;
using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Extensions;
using EntropyServer.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EntropyServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntropyController : ControllerBase
    {
        private readonly ILogger<EntropyController> _logger;
        private readonly IEntropyServiceSelector _entropyServiceSelector;

        public EntropyController(
            ILogger<EntropyController> logger,
            IEntropyServiceSelector entropyServiceSelector)
        {
            _logger = logger;
            _entropyServiceSelector = entropyServiceSelector;
        }

        [HttpGet]
        [Route("[controller]/result?type={entropyType}")]
        public async Task<IActionResult> GetResult([FromQuery] int entropyType)
        {
            if (entropyType.ToEntropyType(out var entropyTypeResult))
            {
                _logger.LogInformation($"Valid entropy type: {entropyTypeResult}, generating entropy.");
                var result = await _entropyServiceSelector.GetResult((EntropyType)entropyType);

                if (result != null)
                    return Ok(result);

                return NotFound();
            }
            
            _logger.LogError($"Invalid entropy type ID: {entropyType}.");
            return BadRequest();
        }
    }
}