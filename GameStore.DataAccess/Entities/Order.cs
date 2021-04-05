using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DataAccess.Entities
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Arrived { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public int CustomerId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Customer Customer { get; set; }


    }
}