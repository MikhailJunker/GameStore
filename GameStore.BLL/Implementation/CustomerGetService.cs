using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.BLL.Contracts;
using GameStore.DataAccess.Contracts;
using GameStore.Domain;
using GameStore.Domain.Contracts;

namespace GameStore.BLL.Implementation
{
    public class CustomerGetService : ICustomerGetService
    {
        private ICustomerDataAccess CustomerDataAccess { get; }

        public CustomerGetService(ICustomerDataAccess customerDataAccess)
        {
            CustomerDataAccess = customerDataAccess;
        }

        public Task<IEnumerable<Customer>> GetAsync()
        {
            return CustomerDataAccess.GetAsync();
        }

        public Task<Customer> GetAsync(ICustomerIdentity customer)
        {
            return CustomerDataAccess.GetAsync(customer);
        }

        public async Task ValidateAsync(ICustomerContainer container)
        {
            if (container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var entity = await CustomerDataAccess.GetByAsync(container);

            if (entity is null)
            {
                throw new InvalidOperationException($"Customer not found by ID {container.CustomerId}");
            }
        }
    }
}