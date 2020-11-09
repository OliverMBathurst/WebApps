using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EntropyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        [HttpGet]
        [Route("typedefinitions")]
        public async Task<IActionResult> GetTypeDefinitions()
        {
            //todo
        }
    }
}
