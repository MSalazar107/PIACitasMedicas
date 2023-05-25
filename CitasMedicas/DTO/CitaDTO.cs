using CitasMedicas.Entidades;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.DTO
{
    public class CitaDTO
    {
        public int Id { get; set; }

        public DateTime fecha { get; set; }

        public DateTime hora { get; set; }

        public int DocId { get; set; }

        public List<Doctor> Doctores { get; set; }
 
        public int PacienteId { get; set; }

        public List<Paciente> Pacientes { get; set; }
    }
}
