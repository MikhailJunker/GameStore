using System;
using GameStore.Domain.Contracts;

namespace GameStore.Domain.Models
{
    public class OrderUpdateModel : IOrderIdentity, IGameContainer, ICustomerContainer
    {
        public int Id { get; set; }

        public bool Arrived { get; set; }

        public DateTime Date { get; set; }

        public int GameId { get; set; }

        public int CustomerId { get; set; }
    }
}