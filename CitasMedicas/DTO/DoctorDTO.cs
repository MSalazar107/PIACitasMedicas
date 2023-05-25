using CitasMedicas.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.DTO
{
    public class DoctorDTO
    {
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

    }
}
