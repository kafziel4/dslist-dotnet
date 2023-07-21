using DSList.Service.Dtos;
using DSList.Service.DTOs;
using DSList.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DSList.API.Controllers
{
    [Route("api/lists")]
    [ApiController]
    public class GameListController : ControllerBase
    {
        private readonly IGameListService _gameListService;
        private readonly IGameService _gameService;

        public GameListController(IGameListService gameListService, IGameService gameService)
        {
            _gameListService = gameListService;
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameListDto>>> FindAll()
        {
            var gameLists = await _gameListService.FindAllAsync();
            return Ok(gameLists);
        }

        [HttpGet("{id}/games")]
        public async Task<ActionResult<IEnumerable<GameMinDto>>> FindByList(long id)
        {
            var gameList = await _gameService.FindByListAsync(id);
            return Ok(gameList);
        }

        [HttpPost("{id}/replacement")]
        public async Task<ActionResult> Move(long id, ReplacementDto body)
        {
            return Ok();
        }
    }
}
