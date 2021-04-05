using System.Threading.Tasks;
using GameStore.BLL.Contracts;
using GameStore.DataAccess.Contracts;
using GameStore.Domain;
using GameStore.Domain.Models;

namespace GameStore.BLL.Implementation
{
    public class GameCreateService : IGameCreateService
    {
        private IGameDataAccess GameDataAccess { get; }

        public GameCreateService(IGameDataAccess gameDataAccess)
        {
            GameDataAccess = gameDataAccess;
        }

        public Task<Game> CreateAsync(GameUpdateModel game)
        {
            return GameDataAccess.InsertAsync(game);
        }
    }
}