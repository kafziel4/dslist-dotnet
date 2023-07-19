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
        private readonly IGameService gameService;

        public GameListController(IGameListService gameListService, IGameService gameService)
        {
            _gameListService = gameListService;
            this.gameService = gameService;
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
            return Ok();
        }
    }
}
