using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMotos_API.Modelos
{
    public class Moto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cilindrada { get; set; }
        public string Color { get; set; }
        public int Año { get; set; }
        public string Motor { get; set; }
        public string Bateria { get; set; }
        public int Peso { get; set; }
        public double Rodado { get; set; }
        public string Suspension { get; set; }
        public string Frenos { get; set; }
        public string ImagenUrl { get; set; }
        public double Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
