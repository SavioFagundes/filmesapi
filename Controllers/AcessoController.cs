using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace usuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessoController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "IdadeMinima")]
        public IActionResult Get()
        {
            return Ok("Acesso permitido");
        }
    }
}