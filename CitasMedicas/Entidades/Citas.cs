using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Entidades
{
    public class Citas
    {
        [Key]
        public int Id { get; set; }   
        
        public DateTime fecha { get; set; }

        public DateTime hora { get; set; }

        public int DocId { get; set; }

        public Doctores Doctores { get; set; }

        
        public int PacienteId { get; set; }

        public Pacientes pacientes { get; set; }
    }
}
