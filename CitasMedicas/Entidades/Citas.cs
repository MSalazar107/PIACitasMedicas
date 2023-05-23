using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Entidades
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }   
        
        public DateTime fecha { get; set; }

        public DateTime hora { get; set; }

        public int DocId { get; set; }

        public Doctor Doctores { get; set; }

        
        public int PacienteId { get; set; }

        public Paciente pacientes { get; set; }
    }
}
