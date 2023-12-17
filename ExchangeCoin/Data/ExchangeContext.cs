using ExchangeCoinApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExchangeCoinApi.Data
{
    public class ExchangeContext : DbContext
    {
        public DbSet<User> usuario { get; set; }
        public DbSet<Coin> monedasUser { get; set; }
        public DbSet<DefaultCoin> monedasDefault { get; set; }
        public DbSet<Subscription> Suscripcion { get; set; }

        public ExchangeContext(DbContextOptions<ExchangeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DefaultCoin pesoArgentino = new DefaultCoin()
            {
                Id = 1,
                Nombre = "Peso Argentino",
                Imagen = "Ars$",
                Valor = 0.002
            };
            DefaultCoin dolarAmericano = new DefaultCoin()
            {
                Id = 2,
                Nombre = "Dolar Americano",
                Imagen = "Usd$",
                Valor = 1
            };
            DefaultCoin coronaCheca = new DefaultCoin()
            {
                Id = 3,
                Nombre = "Corona Checa",
                Imagen = "Kc$",
                Valor = 0.043
            };
            DefaultCoin euro = new DefaultCoin()
            {
                Id = 4,
                Nombre = "Euro",
                Imagen = "Eur$",
                Valor = 1.09
            };

            modelBuilder.Entity<DefaultCoin>().HasData(
               pesoArgentino, dolarAmericano, coronaCheca, euro);

            base.OnModelCreating(modelBuilder);
        }
    }
}