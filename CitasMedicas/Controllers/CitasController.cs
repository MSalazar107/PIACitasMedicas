using CitasMedicas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicas.Controllers
{
    [ApiController]
    [Route("Citas")]
    public class CitasController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CitasController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpPost("Agendar cita")]
        public async Task<ActionResult> Post(Citas cita)
        {
            bool hayConflictos = dbContext.Cita.Any(c =>
              (c.DocId == cita.DocId || c.PacienteId == cita.PacienteId)&&
              c.fecha == cita.fecha &&
              c.hora == cita.hora.AddMinutes(-30)&& c.hora <= cita.hora.AddMinutes(30));

            if (hayConflictos) {
                return BadRequest("La cita se empalma con otra existente");            
            }
            dbContext.Cita.Add(cita);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("lista_de_citas")]

        public async Task<ActionResult<List<Citas>>> GetAll()
        {
            return await dbContext.Cita.ToListAsync();
        }

        [HttpGet("buscar_cita_id")]

        public async Task<ActionResult<Citas>> GetById(int id)
        {
            return await dbContext.Cita.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Citas cita, int id)
        {
            var existedoc = await dbContext.Cita.AnyAsync(x => x.Id == cita.Id);
            if (cita.Id != id)
            {
                return BadRequest("la cita no existe en la base de datos");
            }

            if (cita.Id != id)
            {
                return BadRequest("El id de la cita no coincide con la URL");
            }

            dbContext.Update(cita);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await dbContext.Cita.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound("No se encontro la cita");
            }

            dbContext.Remove(new Citas()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();

        }
    }
}
