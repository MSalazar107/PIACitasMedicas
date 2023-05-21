using Microsoft.EntityFrameworkCore;
using CitasMedicas.Entidades;
namespace CitasMedicas
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions options) :base(options) 
        {

        }

        public DbSet<Citas> Cita { get; set; }
        
        public DbSet <Doctores>Doctor { get; set; }

        public DbSet<Pacientes> Paciente { get; set;}
    }
}
