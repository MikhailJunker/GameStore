using System.Collections.Generic;
using System.Linq;
using GameStore.Domain;
using GameStore.Domain.Contracts;
using System.Threading.Tasks;
using GameStore.Domain.Models;

namespace GameStore.DataAccess.Contracts
{
    public interface IGameDataAccess
    {
        Task<Game> InsertAsync(GameUpdateModel game);
        Task<IEnumerable<Game>> GetAsync();
        Task<Game> GetAsync(IGameIdentity game);
        Task<Game> UpdateAsync(GameUpdateModel game);
        Task<Game> GetByAsync(IGameContainer container);
    }
}