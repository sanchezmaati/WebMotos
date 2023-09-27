using System.ComponentModel.DataAnnotations;

namespace WebMotos_API.Modelos.Dto
{
    public class MotosDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
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
    }
}
