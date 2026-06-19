using Microsoft.AspNetCore.Mvc;

namespace Dsw2026Ej15.Api.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class DoctorsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDoctor()
        {
            return Created();

        }
    }
}
