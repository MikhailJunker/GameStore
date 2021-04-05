using System;
using System.Collections.Generic;
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
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private GameStoreContext context { get; }
        private IMapper mapper { get; }

        public CustomerDataAccess(GameStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Customer> InsertAsync(CustomerUpdateModel customer)
        {
            var result = await context.Customers.AddAsync(mapper.Map<Entities.Customer>(customer));

            await context.SaveChangesAsync();

            return mapper.Map<Customer>(result.Entity);
        }

        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return mapper.Map<IEnumerable<Customer>>(await context.Customers.Include(x => x.Orders).ToListAsync());
        }

        private async Task<Entities.Customer> Get(ICustomerIdentity customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            return await context.Customers.Include(x => x.Orders)
                .FirstOrDefaultAsync(x => x.Id == customer.Id);
        }

        public async Task<Customer> GetAsync(ICustomerIdentity customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            return mapper.Map<Customer>(await Get(customer));
        }

        public async Task<Customer> GetByAsync(ICustomerContainer container)
        {
            return mapper.Map<Customer>(await context.Customers.FirstOrDefaultAsync(x => x.Id == container.CustomerId));
        }

        public async Task<Customer> UpdateAsync(CustomerUpdateModel customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var entity = await context.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id);

            var result = mapper.Map(customer, entity);

            context.Update(result);

            await context.SaveChangesAsync();

            return mapper.Map<Customer>(result);
        }
    }
}