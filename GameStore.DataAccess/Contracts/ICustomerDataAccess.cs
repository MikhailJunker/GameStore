using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain;
using GameStore.Domain.Contracts;
using GameStore.Domain.Models;

namespace GameStore.DataAccess.Contracts
{
    public interface ICustomerDataAccess
    {
        Task<Customer> InsertAsync(CustomerUpdateModel customer);
        Task<IEnumerable<Customer>> GetAsync();
        Task<Customer> GetAsync(ICustomerIdentity customer);
        Task<Customer> UpdateAsync(CustomerUpdateModel customer);
        Task<Customer> GetByAsync(ICustomerContainer container);
    }
}