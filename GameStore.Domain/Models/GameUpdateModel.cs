using GameStore.Domain.Contracts;

namespace GameStore.Domain.Models
{
    public class GameUpdateModel : IGameIdentity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }

        public string Genre { get; set; }

        public int Price { get; set; }
    }
}