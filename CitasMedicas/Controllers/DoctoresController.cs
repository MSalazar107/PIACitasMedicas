using CitasMedicas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicas.Controllers
{
    [ApiController]
    [Route("doctores")]
    public class DoctoresController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public DoctoresController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("Lista de Doctores del Hospital")]

        public async Task<ActionResult<List<Doctores>>> GetAll()
        {
            return await dbContext.Doctor.Include(x => x.CitasM).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Doctores>> GetById(int id)
        {
            return await dbContext.Doctor.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Doctores  doctor)
        {
            dbContext.Add(doctor);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Doctores doctor, int id)
        {
            var existedoc = await dbContext.Doctor.AnyAsync(x => x.Id == doctor.Id);
            if(doctor.Id != id) 
            {
                return BadRequest("No existe doctor en la base de datos");
            }

            if(doctor.Id != id)
            {
                return BadRequest("El id del doctor no coincide con la URL");
            }

            dbContext.Update(doctor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Doctor.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El Recurso no fue encontrado.");
            }

            dbContext.Remove(new Doctores()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
