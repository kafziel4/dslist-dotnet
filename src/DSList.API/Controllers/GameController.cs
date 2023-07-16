using DSList.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DSList.API.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameMinDto>>> FindAll()
        {
            return Ok();
        }
    }
}
