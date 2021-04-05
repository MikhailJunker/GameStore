using GameStore.Domain.Contracts;

namespace GameStore.Domain.Models
{
    public class CustomerIndentityModel : ICustomerIdentity
    {
        public int Id { get; }

        public CustomerIndentityModel(int id)
        {
            Id = id;
        }
    }
}