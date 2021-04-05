using System;
using System.Collections.Generic;
using System.Text;
using GameStore.Domain.Contracts;

namespace GameStore.Domain
{
    public class Order : IGameContainer, ICustomerContainer
    {
        public int Id { get; set; }

        public bool Arrived { get; set; }

        public DateTime Date { get; set; }

        public Game Game { get; set; }

        public Customer Customer { get; set; }

        public int GameId => Game.Id;

        public int CustomerId => Customer.Id;

    }
}
