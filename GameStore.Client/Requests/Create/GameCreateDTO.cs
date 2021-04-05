using System.ComponentModel.DataAnnotations;

namespace GameStore.Client.Requests.Create
{
    public class GameCreateDTO
    {
        [Required(ErrorMessage = "Game title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Game release year is required")]
        public string Year { get; set; }

        public string Genre { get; set; }

        [Required(ErrorMessage = "Game price is required")]
        public int Price { get; set; }
    }
}