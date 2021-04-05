using System.Threading.Tasks;
using GameStore.BLL.Contracts;
using GameStore.DataAccess.Contracts;
using GameStore.Domain;
using GameStore.Domain.Models;

namespace GameStore.BLL.Implementation
{
    public class OrderUpdateService : IOrderUpdateService
    {
        private IOrderDataAccess OrderDataAccess { get; }
        private IGameGetService GameGetService { get; }
        private ICustomerGetService CustomerGetService { get; }

        public OrderUpdateService(IOrderDataAccess orderDataAccess, IGameGetService gameGetService, ICustomerGetService customerGetService)
        {
            OrderDataAccess = orderDataAccess;
            GameGetService = gameGetService;
            CustomerGetService = customerGetService;
        }

        public async Task<Order> UpdateAsync(OrderUpdateModel order)
        {
            await GameGetService.ValidateAsync(order);
            await CustomerGetService.ValidateAsync(order);

            return await OrderDataAccess.UpdateAsync(order);
        }
    }
}