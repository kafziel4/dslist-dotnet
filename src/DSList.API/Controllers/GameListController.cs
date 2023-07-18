using DSList.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DSList.API.Controllers
{
    [Route("api/lists")]
    [ApiController]
    public class GameListController : ControllerBase
    {
        private readonly IGameListService _gameListService;

        public GameListController(IGameListService gameListService)
        {
            _gameListService = gameListService;
        }
    }
}
