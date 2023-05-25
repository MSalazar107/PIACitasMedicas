using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CitasMedicas.Validaciones;

namespace CitasMedicas.Entidades
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }   
        
        public DateTime fecha { get; set; }

        public DateTime hora { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")] //
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        public int DocId { get; set; }

        public List<Doctor> Doctores { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] //
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        public int PacienteId { get; set; }

        [NotMapped]
        public List<DoctorCitas> DoctorCitas { get; set; }
    }
}
