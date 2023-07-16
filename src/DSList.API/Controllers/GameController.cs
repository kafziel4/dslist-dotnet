using DSList.Service.Dtos;
using DSList.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DSList.API.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameMinDto>>> FindAll()
        {
            var games = await _gameService.FindAllAsync();
            return Ok(games);
        }
    }
}
