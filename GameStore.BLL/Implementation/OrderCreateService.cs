using System;
using System.Threading.Tasks;
using GameStore.BLL.Contracts;
using GameStore.DataAccess.Contracts;
using GameStore.Domain;
using GameStore.Domain.Models;

namespace GameStore.BLL.Implementation
{
    public class OrderCreateService : IOrderCreateService
    {
        private IOrderDataAccess OrderDataAccess { get; }
        private IGameGetService GameGetService { get; }
        private ICustomerGetService CustomerGetService { get; }

        public OrderCreateService(IOrderDataAccess orderDataAccess, IGameGetService gameGetService, ICustomerGetService customerGetService)
        {
            OrderDataAccess = orderDataAccess;
            GameGetService = gameGetService;
            CustomerGetService = customerGetService;
        }

        public async Task<Order> CreateAsync(OrderUpdateModel order)
        {
            await GameGetService.ValidateAsync(order);
            await CustomerGetService.ValidateAsync(order);

            order.Date = DateTime.Now;
            order.Arrived = false;

            return await OrderDataAccess.InsertAsync(order);
        }
    }
}