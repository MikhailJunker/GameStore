using System.Threading.Tasks;
using GameStore.Domain;
using GameStore.Domain.Models;

namespace GameStore.BLL.Contracts
{
    public interface ICustomerUpdateService
    {
        Task<Customer> UpdateAsync(CustomerUpdateModel customer);
    }
}