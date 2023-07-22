using AutoMapper;
using DSList.Data.Interfaces;
using DSList.Service.DTOs;
using DSList.Service.Interfaces;

namespace DSList.Service.Services
{
    public class GameListService : IGameListService
    {
        private readonly IGameListRepository _repository;
        private readonly IMapper _mapper;

        public GameListService(IGameListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameListDto>> FindAllAsync()
        {
            var result = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<GameListDto>>(result);
        }

        public async Task MoveAsync(long listId, int sourceIndex, int destinationIndex)
        {
            var list = await _repository.SearchBelongingsByListAsync(listId);
            var item = list[sourceIndex];
            list.Remove(item);
            list.Insert(destinationIndex, item);

            var min = sourceIndex < destinationIndex ? sourceIndex : destinationIndex;
            var max = sourceIndex < destinationIndex ? destinationIndex : sourceIndex;

            for (int i = min; i <= max; i++)
            {
                list[i].Position = i;
            }

            await _repository.SaveChangesAsync();
        }
    }
}
