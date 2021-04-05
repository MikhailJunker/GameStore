using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain;
using GameStore.Domain.Contracts;
using GameStore.Domain.Models;

namespace GameStore.DataAccess.Contracts
{
    public interface IOrderDataAccess
    {
        Task<Order> InsertAsync(OrderUpdateModel order);
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> GetAsync(IOrderIdentity order);
        Task<Order> UpdateAsync(OrderUpdateModel order);
        Task<IEnumerable<Order>> GetByGameAsync(IGameIdentity game);
        Task<IEnumerable<Order>> GetByCustomerAsync(ICustomerIdentity customer);
    }
}