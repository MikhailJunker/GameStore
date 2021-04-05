using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.DataAccess.Context;
using GameStore.DataAccess.Contracts;
using GameStore.Domain;
using GameStore.Domain.Contracts;
using GameStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DataAccess.Implementations
{
    public class OrderDataAccess : IOrderDataAccess
    {
        private GameStoreContext context { get; }
        private IMapper mapper { get; }

        public OrderDataAccess(GameStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Order> InsertAsync(OrderUpdateModel order)
        {
            var result = await context.Orders.AddAsync(mapper.Map<Entities.Order>(order));

            await context.SaveChangesAsync();

            return mapper.Map<Order>(result.Entity);
        }

        public async Task<IEnumerable<Order>> GetAsync()
        {
            return mapper.Map<IEnumerable<Order>>(await context.Orders.Include(x => x.Game).Include(x => x.Customer).ToListAsync());
        }

        private async Task<Entities.Order> Get(IOrderIdentity order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            return await context.Orders.Include(x => x.Game).Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == order.Id);
        }

        public async Task<Order> GetAsync(IOrderIdentity order)
        {
            var entity = await Get(order);

            return mapper.Map<Order>(entity);
        }

        public async Task<Order> UpdateAsync(OrderUpdateModel order)
        {
            var entity = await Get(order);

            var result = mapper.Map(order, entity);

            context.Update(result);

            await context.SaveChangesAsync();

            return mapper.Map<Order>(result);
        }

        public async Task<IEnumerable<Order>> GetByGameAsync(IGameIdentity game)
        {
            return mapper.Map<IEnumerable<Order>>(await context.Orders.Where(x => x.GameId == game.Id).Include(x => x.Game)
                .Include(x => x.Customer).ToListAsync());
        }

        public async Task<IEnumerable<Order>> GetByCustomerAsync(ICustomerIdentity customer)
        {
            return mapper.Map<IEnumerable<Order>>(await context.Orders.Where(x => x.CustomerId == customer.Id).Include(x => x.Game)
                .Include(x => x.Customer).ToListAsync());
        }
    }
}