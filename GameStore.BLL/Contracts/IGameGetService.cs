using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Domain;
using GameStore.Domain.Contracts;

namespace GameStore.BLL.Contracts
{
    public interface IGameGetService
    {
        Task<IEnumerable<Game>> GetAsync();
        Task<Game> GetAsync(IGameIdentity game);

        Task ValidateAsync(IGameContainer container);
    }
}