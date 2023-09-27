using WebMotos_API.Modelos.Dto;

namespace WebMotos_API.Datos
{
    public static class MotosStore
    {
        public static List<MotosDto> motosList = new List<MotosDto>
        {
            new MotosDto { Id = 1, Marca = "Yamaha", Modelo = "YBR 125", Cilindrada = "125cc"},
            new MotosDto { Id = 2, Marca = "Gilera", Modelo = "Smash 110", Cilindrada = "110cc" }
        };
    }
}
