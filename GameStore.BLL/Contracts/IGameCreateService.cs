using System.Threading.Tasks;
using GameStore.Domain;
using GameStore.Domain.Models;

namespace GameStore.BLL.Contracts
{
    public interface IGameCreateService
    {
        Task<Game> CreateAsync(GameUpdateModel game);
    }
}