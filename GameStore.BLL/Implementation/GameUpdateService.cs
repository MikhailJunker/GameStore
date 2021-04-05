using System.Threading.Tasks;
using GameStore.BLL.Contracts;
using GameStore.DataAccess.Contracts;
using GameStore.Domain;
using GameStore.Domain.Models;

namespace GameStore.BLL.Implementation
{
    public class GameUpdateService : IGameUpdateService
    {
        private IGameDataAccess GameDataAccess { get; }

        public GameUpdateService(IGameDataAccess gameDataAccess)
        {
            GameDataAccess = gameDataAccess;
        }

        public Task<Game> UpdateAsync(GameUpdateModel game)
        {
            return GameDataAccess.UpdateAsync(game);
        }
    }
}