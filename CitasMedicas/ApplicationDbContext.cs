using Microsoft.EntityFrameworkCore;
using CitasMedicas.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CitasMedicas
{
    public class ApplicationDbContext : IdentityDbContext 
    {
        public ApplicationDbContext(DbContextOptions options) :base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DoctorCitas>()
                .HasKey(al => new { al.DoctorId, al.CitaId });
            modelBuilder.Entity<PacienteCitas>()
                .HasKey(al => new { al.PacienteId, al.CitaId });
        }


        public DbSet<Cita> Cita { get; set; }

        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<DoctorCitas> DoctorCitas { get; set; }
        public DbSet<PacienteCitas> PacienteCitas { get; set; }

    }
}
