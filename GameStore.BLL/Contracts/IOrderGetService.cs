using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Domain;
using GameStore.Domain.Contracts;

namespace GameStore.BLL.Contracts
{
    public interface IOrderGetService
    {
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> GetAsync(IOrderIdentity order);
        Task<IEnumerable<Order>> GetByGameAsync(IGameIdentity game);
        Task<IEnumerable<Order>> GetByCustomerAsync(ICustomerIdentity customer);
    }
}