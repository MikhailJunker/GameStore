using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GameStore.Client.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }

        public string Genre { get; set; }

        public int Price { get; set; }

        [JsonIgnore]
        public ICollection<OrderDTO> Orders { get; set; }
    }
}
