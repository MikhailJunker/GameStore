using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Client.Requests.Create
{
    public class OrderCreateDTO
    {
        [Required(ErrorMessage = "Game ID is required")]
        public int GameId { get; set; }

        [Required(ErrorMessage = "Customer ID is required")]
        public int CustomerId { get; set; }

        public bool Arrived { get; set; }

        public DateTime Date { get; set; }
    }
}