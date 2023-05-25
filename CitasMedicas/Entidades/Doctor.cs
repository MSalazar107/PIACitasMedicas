using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CitasMedicas.Validaciones;

namespace CitasMedicas.Entidades
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        [PrimeraLetraMayuscula]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        [PrimeraLetraMayuscula]
        public string especialidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        public string consultorio { get; set; }

        [NotMapped]
        public List<DoctorCitas> DoctorCitas { get; set; }
    }
}
