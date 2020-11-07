using EntropyServer.Domain.Enums;
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
        private readonly IEntropyServiceMapper _entropyServiceMapper;
        private readonly IEntropyTypeRepository _entropyTypeRepository;

        public EntropyController(
            ILogger<EntropyController> logger,
            IEntropyServiceMapper entropyServiceMapper,
            IEntropyTypeRepository entropyTypeRepository)
        {
            _logger = logger;
            _entropyServiceMapper = entropyServiceMapper;
            _entropyTypeRepository = entropyTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEntropyResult([FromQuery] EntropyFilterDto entropyFilterDto)
        {
            if (_entropyTypeRepository.ToEntropyType(entropyFilterDto.EntropyTypeID, out var entropyType))
            {
                _logger.LogInformation($"Valid entropy type: {entropyType}, generating entropy.");

                return entropyType switch
                {
                    EntropyType.Int => Ok(await _entropyServiceMapper.GetService<int>().GetResult()),
                    _ => BadRequest()
                };
            }
            else
            {
                _logger.LogError($"Invalid entropy type ID: {entropyFilterDto.EntropyTypeID}.");
                return BadRequest();
            }
        }
    }
}