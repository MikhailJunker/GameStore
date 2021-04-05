using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Domain;
using GameStore.Domain.Contracts;

namespace GameStore.BLL.Contracts
{
    public interface ICustomerGetService
    {
        Task<IEnumerable<Customer>> GetAsync();
        Task<Customer> GetAsync(ICustomerIdentity customer);
        Task ValidateAsync(ICustomerContainer container);


    }
}