using System;

namespace GameStore.Client.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public bool Arrived { get; set; }

        public DateTime Date { get; set; }

        public GameDTO Game { get; set; }

        public CustomerDTO Customer { get; set; }

        
    }
}