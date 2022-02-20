using Microsoft.EntityFrameworkCore;
using Trades.Entities;

namespace Trades.DataBase
{
    public class DataContext : DbContext
    {
        public DbSet<Trade> Trades { get; set; }
        public DbSet<CounterParty> CounterParty { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.; Database= estudoDB;Integrated Security=SSPI; ";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected void onModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trade>()
                .HasOne(t => t.CounterParty)
                .WithMany(cp => cp.trades)
                .HasForeignKey(t => t.CounterPartyId);
        }
    }
}
