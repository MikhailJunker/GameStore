using GameStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DataAccess.Context
{
    public class GameStoreContext : DbContext
    {
        protected GameStoreContext()
        {
        }

        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Game)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(d => d.GameId);

                entity.HasOne(d => d.Customer)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(d => d.CustomerId);
            });
        }
    }
}