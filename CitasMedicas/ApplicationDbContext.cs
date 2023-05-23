using Microsoft.EntityFrameworkCore;
using CitasMedicas.Entidades;
namespace CitasMedicas
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions options) :base(options) 
        {

        }

        public DbSet<Cita> Cita { get; set; }

        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<Paciente> Paciente { get; set; }
    }
}
