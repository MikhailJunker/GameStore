using System.Threading.Tasks;
using GameStore.BLL.Contracts;
using GameStore.DataAccess.Contracts;
using GameStore.Domain;
using GameStore.Domain.Models;

namespace GameStore.BLL.Implementation
{
    public class CustomerCreateService : ICustomerCreateService
    {
        private ICustomerDataAccess CustomerDataAccess { get; }

        public CustomerCreateService(ICustomerDataAccess customerDataAccess)
        {
            CustomerDataAccess = customerDataAccess;
        }

        public Task<Customer> CreateAsync(CustomerUpdateModel customer)
        {
            return CustomerDataAccess.InsertAsync(customer);
        }
    }
}