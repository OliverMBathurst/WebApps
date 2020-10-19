using System.Threading.Tasks;
using EntropyServer.Domain.Enums;
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
            var type = (EntropyType)entropyType;

            var result = await _entropyServiceSelector.GetResult(type);

            return new OkObjectResult(result);
        }
    }
}