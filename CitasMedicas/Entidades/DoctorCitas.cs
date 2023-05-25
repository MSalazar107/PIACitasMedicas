using Microsoft.EntityFrameworkCore;

namespace CitasMedicas.Entidades
{
    [Keyless]
    public class DoctorCitas 
    {
        
        public int DoctorId { get; set; }
        public int CitaId { get; set; }
        public Doctor Doctor { get; set; }
        public Cita Cita { get; set; }
    }
}
