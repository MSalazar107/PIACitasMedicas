using CitasMedicas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace CitasMedicas.Controllers
{
    [ApiController]
    [Route("Pacientes")]
    public class PacientesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PacientesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("Lista de pacientes")]
        public async Task<ActionResult<List<Pacientes>>> GetAll()
        {
            return await dbContext.Paciente.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pacientes>> GetById(int id)
        {
            return await dbContext.Paciente.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]

        public async Task<ActionResult> Post(Pacientes paciente)
        {
            dbContext.Add(paciente);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Buscar paciente por id")]

        public async Task<ActionResult> Put(Pacientes paciente, int id)
        {
            var existepac = await dbContext.Doctor.AnyAsync(x => x.Id == paciente.Id);
            if (paciente.Id != id)
            {
                return BadRequest("No existe doctor en la base de datos");
            }

            if (paciente.Id != id)
            {
                return BadRequest("El id del doctor no coincide con la URL");
            }

            dbContext.Update(paciente);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Paciente.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El Recurso no fue encontrado.");
            }

            dbContext.Remove(new Pacientes()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
