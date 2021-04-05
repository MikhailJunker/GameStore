using GameStore.Domain.Contracts;

namespace GameStore.Domain.Models
{
    public class CustomerUpdateModel : ICustomerIdentity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Addres { get; set; }

        public string Phone { get; set; }
    }
}