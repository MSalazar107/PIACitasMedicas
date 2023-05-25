using CitasMedicas.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.DTO
{
    public class PacienteDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        [PrimeraLetraMayuscula]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int edad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 15, ErrorMessage = "El campo {0} solo puede tener hasta 15 caracteres")]
        public long telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        public string email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        public string direccion { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [StringLength(maximumLength: 3, ErrorMessage = "El campo {0} solo puede tener hasta 3 caracteres")]
        public float peso { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [StringLength(maximumLength: 5, ErrorMessage = "El campo {0} solo puede tener hasta 5 caracteres")]
        public float altura { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        public string hisorialEnfermedades { get; set; }
    }
}
