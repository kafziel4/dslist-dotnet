using AutoMapper;
using DSList.Data.Interfaces;
using DSList.Service.Dtos;
using DSList.Service.Interfaces;

namespace DSList.Service.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameMinDto>> FindAllAsync()
        {
            var result = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<GameMinDto>>(result);
        }
    }
}
