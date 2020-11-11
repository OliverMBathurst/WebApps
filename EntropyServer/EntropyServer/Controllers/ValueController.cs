using EntropyServer.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntropyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly IEntropyTypeRepository _entropyTypeRepository;

        public ValueController(IEntropyTypeRepository entropyTypeRepository) 
        {
            _entropyTypeRepository = entropyTypeRepository;
        }

        [HttpGet]
        [Route("typedefinitions")]
        public IActionResult GetTypeDefinitions()
        {
            var definitions = _entropyTypeRepository.Definitions;
            return Ok(definitions);
        }
    }
}
