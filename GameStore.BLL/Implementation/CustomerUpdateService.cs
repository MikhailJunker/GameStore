using System.Threading.Tasks;
using GameStore.BLL.Contracts;
using GameStore.DataAccess.Contracts;
using GameStore.Domain;
using GameStore.Domain.Models;

namespace GameStore.BLL.Implementation
{
    public class CustomerUpdateService : ICustomerUpdateService
    {
        private ICustomerDataAccess CustomerDataAccess { get; }

        public CustomerUpdateService(ICustomerDataAccess customerDataAccess)
        {
            CustomerDataAccess = customerDataAccess;
        }

        public Task<Customer> UpdateAsync(CustomerUpdateModel customer)
        {
            return CustomerDataAccess.UpdateAsync(customer);
        }
    }
}