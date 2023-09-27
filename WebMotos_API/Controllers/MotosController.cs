using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebMotos_API.Datos;
using WebMotos_API.Modelos;
using WebMotos_API.Modelos.Dto;

namespace WebMotos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotosController : ControllerBase
    {
        private readonly ILogger<MotosController> _logger;
        private readonly ApplicationDbContext _db;

        public MotosController(ILogger<MotosController> logger, ApplicationDbContext db) 
        {
            _logger = logger;
            _db = db; 
        }    


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<MotosDto>> GetMotos()
        {
            _logger.LogInformation("Obtener todas las motos");
            return Ok(_db.Motos.ToList());

        }

        [HttpGet("id:int", Name = "GetMoto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MotosDto> GetMotos(int id)
        {
            if (id <= 0)
            {
                _logger.LogError("Error al obtener la moto con Id: " +  id);
                return BadRequest();
            }
            //var moto = MotosStore.motosList.FirstOrDefault(m => m.Id == id);
            var moto = _db.Motos.FirstOrDefault(m => m.Id == id);

            if (moto == null)
            {
                return NotFound();
            }

            return Ok(moto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MotosDto> CrearMoto([FromBody] MotosDto motosDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*if(_db.Motos.FirstOrDefault(m=>m.Marca.ToLower() == motosDto.Marca.ToLower()) != null)
            {
                ModelState.AddModelError("MarcaExiste", "La Marca ya existe");
            }*/

            if (motosDto == null)
            {
                return BadRequest();
            }

            if (motosDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Moto modelo = new()
            {
                Marca = motosDto.Marca,
                Modelo = motosDto.Modelo,
                Cilindrada = motosDto.Cilindrada,
                Color = motosDto.Color,
                Año = motosDto.Año,
                Motor = motosDto.Motor,
                Bateria = motosDto.Bateria,
                Peso = motosDto.Peso,
                Rodado = motosDto.Rodado,
                Suspension = motosDto.Suspension,
                Frenos = motosDto.Frenos,
                ImagenUrl = motosDto.ImagenUrl,
                Precio = motosDto.Precio
            };
            _db.Motos.Add(modelo);
            _db.SaveChanges();

            return CreatedAtRoute("GetMoto", new { id = motosDto.Id }, motosDto);
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteMoto(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var moto = _db.Motos.FirstOrDefault(m=>m.Id == id);
            if (moto == null)
            {
                return NotFound();
            }
            _db.Motos.Remove(moto);
            _db.SaveChanges();

            return NoContent();
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateMoto(int id, [FromBody] MotosDto motosDto)
        {
            if (motosDto == null || id!= motosDto.Id)
            {
                return BadRequest();
            }
            //var moto = MotosStore.motosList.FirstOrDefault(m => m.Id == id);
            //moto.Marca = motosDto.Marca;
            //moto.Modelo = motosDto.Modelo;
            //moto.Cilindrada = motosDto.Cilindrada;

            Moto modelo = new()
            {
                Id = motosDto.Id,
                Marca = motosDto.Marca,
                Modelo = motosDto.Modelo,
                Cilindrada = motosDto.Cilindrada,
                Color = motosDto.Color,
                Año = motosDto.Año,
                Motor = motosDto.Motor,
                Bateria = motosDto.Bateria,
                Peso = motosDto.Peso,
                Rodado = motosDto.Rodado,
                Suspension = motosDto.Suspension,
                Frenos = motosDto.Frenos,
                ImagenUrl = motosDto.ImagenUrl,
                Precio = motosDto.Precio
            };
            _db.Motos.Update(modelo);
            _db.SaveChanges();
            return NoContent();

        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateParcialMoto(int id, JsonPatchDocument<MotosDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            //var moto = MotosStore.motosList.FirstOrDefault(m => m.Id == id);
            var moto = _db.Motos.FirstOrDefault (m => m.Id == id);

            MotosDto motosDto = new()
            {
                Id = moto.Id,
                Marca = moto.Marca,
                Modelo = moto.Modelo,
                Cilindrada = moto.Cilindrada,
                Color = moto.Color,
                Año = moto.Año,
                Motor = moto.Motor,
                Bateria = moto.Bateria,
                Peso = moto.Peso,
                Rodado = moto.Rodado,
                Suspension = moto.Suspension,
                Frenos = moto.Frenos,
                ImagenUrl = moto.ImagenUrl,
                Precio = moto.Precio
            };

            if (moto == null) return BadRequest();


            patchDto.ApplyTo(motosDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Moto modelo = new()
            {
                Id = motosDto.Id,
                Marca = motosDto.Marca,
                Modelo = motosDto.Modelo,
                Cilindrada = motosDto.Cilindrada,
                Color = motosDto.Color,
                Año = motosDto.Año,
                Motor = motosDto.Motor,
                Bateria = motosDto.Bateria,
                Peso = motosDto.Peso,
                Rodado = motosDto.Rodado,
                Suspension = motosDto.Suspension,
                Frenos = motosDto.Frenos,
                ImagenUrl = motosDto.ImagenUrl,
                Precio = motosDto.Precio
            };

            _db.Motos.Update(modelo);
            _db.SaveChanges();

            return NoContent();

        }
    }
}
