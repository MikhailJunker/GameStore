using System.Threading.Tasks;
using GameStore.Domain;
using GameStore.Domain.Models;

namespace GameStore.BLL.Contracts
{
    public interface IGameUpdateService
    {
        Task<Game> UpdateAsync(GameUpdateModel game);
    }
}