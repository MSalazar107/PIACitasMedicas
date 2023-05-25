using Microsoft.EntityFrameworkCore;

namespace CitasMedicas.Entidades
{
    [Keyless]
    public class PacienteCitas
    {
        public int PacienteId { get; set; }
        public int CitaId { get; set; }
        public Paciente Paciente { get; set; }
        public Cita Cita { get; set; }
    }
}
