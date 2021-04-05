using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.BLL.Contracts;
using GameStore.DataAccess.Contracts;
using GameStore.Domain;
using GameStore.Domain.Contracts;

namespace GameStore.BLL.Implementation
{
    public class GameGetService : IGameGetService
    {
        private IGameDataAccess GameDataAccess { get; }

        public GameGetService(IGameDataAccess gameDataAccess)
        {
            GameDataAccess = gameDataAccess;
        }

        public Task<IEnumerable<Game>> GetAsync()
        {
            return GameDataAccess.GetAsync();
        }

        public Task<Game> GetAsync(IGameIdentity game)
        {
            return GameDataAccess.GetAsync(game);
        }

        public async Task ValidateAsync(IGameContainer container)
        {
            if (container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var entity = await GameDataAccess.GetByAsync(container);

            if (entity is null)
            {
                throw new InvalidOperationException($"Game not found by ID {container.GameId}");
            }
        }
    }
}