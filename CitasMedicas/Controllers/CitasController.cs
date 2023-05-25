using AutoMapper;
using CitasMedicas.DTO;
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
        private readonly IMapper mapper;

        public CitasController(ApplicationDbContext dbContext, IMapper mapper) 
        {
            this.dbContext = dbContext;
            this.mapper = mapper;

        }

        [HttpPost("Agendar cita")]
        public async Task<ActionResult> Post(Cita cita)
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

        public async Task<ActionResult<List<Cita>>> GetAll()
        {
            return await dbContext.Cita.Include(x => x.Doctores).ToListAsync();
        }

        [HttpGet("buscar_cita_id")]

        public async Task<ActionResult<CitaDTOConDoctor>> GetById(int id)
        {
            var cita = await dbContext.Cita.FirstOrDefaultAsync(citaBD => citaBD.Id == id);
            if (cita == null)
            {
                return NotFound();
            }

            return mapper.Map<CitaDTOConDoctor>(cita);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Cita cita, int id)
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

            dbContext.Remove(new Cita()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();

        }
    }
}
