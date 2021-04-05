using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DataAccess.Entities
{
    public class Game
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }
        public string Genre { get; set; }
        [Required]
        public int Price { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}