using AutoMapper;
using CitasMedicas.DTO;
using CitasMedicas.Entidades;
using CitasMedicas.Filtros;
using CitasMedicas.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicas.Controllers
{
    [ApiController]
    [Route("doctores")]
    public class DoctoresController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;
        private readonly IService service;
        private readonly ILogger<DoctoresController> logger;
        private readonly IConfiguration configuration;
        public DoctoresController(ApplicationDbContext dbContext, IService service,
            ServiceTransient serviceTransient, ServiceScoped serviceScoped
            ,ServiceSingleton serviceSingleton, ILogger<DoctoresController>logger, IMapper mapper, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet("Lista de Doctores del Hospital")]
        [AllowAnonymous]
        [ResponseCache(Duration = 15)]
        [ServiceFilter(typeof(FiltroDeAccion))]

        public async Task<ActionResult<List<GetDoctorDTO>>> Get()
        {
            logger.LogInformation("Obteniendo informacion de la lista de doctores");
            service.EjecutarJob();
            var doctores = await dbContext.Doctor.ToListAsync();
            return mapper.Map<List<GetDoctorDTO>>(doctores);
         }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<DoctorDTOConCitas>> Get(int id)
        {
            var doctor = await dbContext.Doctor
                .Include(doctorDB => doctorDB.DoctorCitas)
                .ThenInclude(doctorCitaDB => doctorCitaDB.Cita)
                .FirstOrDefaultAsync(doctorBD => doctorBD.Id == id);
            
            //var doctor = await dbContext.Doctor.FirstOrDefaultAsync(doctorBD => doctorBD.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return mapper.Map<DoctorDTOConCitas>(doctor);
        }
        
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult> Post([FromBody] DoctorDTO doctorDto)
        {
            var existeDoctorMismoNombre = await dbContext.Doctor.AnyAsync(x => x.nombre == doctorDto.nombre);

            if (existeDoctorMismoNombre)
            {
                return BadRequest($"Ya existe un Doctor con el nombre {doctorDto.nombre}");
            }

            var doctor = mapper.Map<Doctor>(doctorDto);

            dbContext.Add(doctor);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult> Put(GetDoctorDTO doctorCreacionDTO, int id)
        {
            var existedoc = await dbContext.Doctor.AnyAsync(x => x.Id == doctorCreacionDTO.Id);
            if (!existedoc)
            {
                return BadRequest("No existe doctor en la base de datos");
            }


            var doctor = mapper.Map<Doctor>(doctorCreacionDTO);
            doctor.Id = id;

            dbContext.Update(doctor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Doctor.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El Recurso no fue encontrado.");
            }

            dbContext.Remove(new Doctor()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
