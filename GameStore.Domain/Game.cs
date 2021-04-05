using System;
using System.Collections.Generic;

namespace GameStore.Domain
{
    public class Game
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }

        public string Genre { get; set; }

        public int Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
