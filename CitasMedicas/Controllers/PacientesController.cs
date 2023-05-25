using AutoMapper;
using CitasMedicas.DTO;
using CitasMedicas.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;


namespace CitasMedicas.Controllers
{
    [ApiController]
    [Route("Pacientes")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Doctor")]
    public class PacientesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public PacientesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet("Lista de pacientes")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetPacienteDTO>>> Get()
        {
            var pacientes = await dbContext.Paciente.ToListAsync();
            return mapper.Map<List<GetPacienteDTO>>(pacientes);
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<PacienteDTO>> Get(int id)
        {
            var paciente = await dbContext.Paciente.FirstOrDefaultAsync(pacienteBD => pacienteBD.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return mapper.Map<PacienteDTO>(paciente);
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] PacienteDTO pacienteDto)
        {
           
            var paciente = mapper.Map<Paciente>(pacienteDto);

            dbContext.Add(paciente);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Buscar paciente por id")]
        [AllowAnonymous]

        public async Task<ActionResult> Put(GetPacienteDTO pacienteCreacionDTO, int id)
        {
            var exist = await dbContext.Paciente.AnyAsync(x => x.Id == pacienteCreacionDTO.Id);
            if (!exist)
            {
                return BadRequest("No existe el paciente en la base de datos");
            }

            var paciente = mapper.Map<Paciente>(pacienteCreacionDTO);
            paciente.Id = id;

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

            dbContext.Remove(new Paciente()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
