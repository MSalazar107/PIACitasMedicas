using CitasMedicas.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.DTO
{
    public class CitaPatchDTO
    {
        public DateTime fecha { get; set; }

        public DateTime hora { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        public List<int> DocId { get; set; }
    }
}
