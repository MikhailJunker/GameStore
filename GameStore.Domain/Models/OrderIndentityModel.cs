using GameStore.Domain.Contracts;

namespace GameStore.Domain.Models
{
    public class OrderIndentityModel : IOrderIdentity
    {
        public int Id { get; }

        public OrderIndentityModel(int id)
        {
            Id = id;
        }
    }
}