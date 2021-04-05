using System.Threading.Tasks;
using GameStore.Domain;
using GameStore.Domain.Models;

namespace GameStore.BLL.Contracts
{
    public interface IOrderCreateService
    {
        public Task<Order> CreateAsync(OrderUpdateModel order);
    }
}