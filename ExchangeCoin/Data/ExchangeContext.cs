using ExchangeCoinApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExchangeCoinApi.Data
{
    public class ExchangeContext : DbContext
    {
        public ExchangeContext(DbContextOptions<ExchangeContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Subscription> Subs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasData(
                    new User()
                    {
                        Id = 1,
                        Nombre = "Alvaro",
                        Usuario = "Alvi",
                        Contrasenia = "123456789",
                    },
            modelBuilder.Entity<Coin>()
                .HasOne<User>(c => c.User));
            modelBuilder.Entity<User>()
                .HasMany<Coin>(u => u.Coins)
                .WithOne(u => u.User);
            modelBuilder.Entity<Subscription>()
                .HasOne<User>(s => s.User);
        }
    }
}