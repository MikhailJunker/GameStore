using System.Threading.Tasks;
using GameStore.Domain;
using GameStore.Domain.Models;

namespace GameStore.BLL.Contracts
{
    public interface IOrderUpdateService
    {
        public Task<Order> UpdateAsync(OrderUpdateModel order);
    }
}