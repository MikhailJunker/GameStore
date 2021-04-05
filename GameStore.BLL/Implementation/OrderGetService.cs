using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.BLL.Contracts;
using GameStore.DataAccess.Contracts;
using GameStore.Domain;
using GameStore.Domain.Contracts;

namespace GameStore.BLL.Implementation
{
    public class OrderGetService : IOrderGetService
    {
        private IOrderDataAccess OrderDataAccess { get; }

        public OrderGetService(IOrderDataAccess orderDataAccess)
        {
            OrderDataAccess = orderDataAccess;
        }

        public Task<IEnumerable<Order>> GetAsync()
        {
            return OrderDataAccess.GetAsync();
        }

        public Task<Order> GetAsync(IOrderIdentity order)
        {
            return OrderDataAccess.GetAsync(order);
        }

        public Task<IEnumerable<Order>> GetByGameAsync(IGameIdentity game)
        {
            return OrderDataAccess.GetByGameAsync(game);
        }

        public Task<IEnumerable<Order>> GetByCustomerAsync(ICustomerIdentity customer)
        {
            return OrderDataAccess.GetByCustomerAsync(customer);
        }
    }
}