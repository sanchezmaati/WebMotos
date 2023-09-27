using Microsoft.EntityFrameworkCore;
using WebMotos_API.Modelos;

namespace WebMotos_API.Datos
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Moto> Motos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moto>().HasData(
                new Moto()
                {
                    Id = 1,
                    Marca = "Yamaha",
                    Modelo = "YBR 125 ED",
                    Cilindrada = "124 cc",
                    Color = "Rojo",
                    Año = 2018,
                    Motor = "Monocilíndrico, 4 tiempos",
                    Bateria = "YTX7L-BS 12V 6Ah",
                    Peso = 123,
                    Rodado = 18,
                    Suspension = "Doble amortiguador",
                    Frenos = "Disco / Tambor",
                    ImagenUrl = "",
                    Precio = 1367750.00,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                },
                new Moto()
                {
                    Id = 2,
                    Marca = "Gilera",
                    Modelo = "Smash 110 Tunning",
                    Cilindrada = "107 cc",
                    Color = "Negro",
                    Año = 2017,
                    Motor = "Monocilíndrico, 4 tiempos",
                    Bateria = "BB5LB 12V 5Ah",
                    Peso = 100,
                    Rodado = 13,
                    Suspension = "Doble amortiguador",
                    Frenos = "Disco / Tambor",
                    ImagenUrl = "",
                    Precio = 623700.00,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                }
                );
        }


    }
}
