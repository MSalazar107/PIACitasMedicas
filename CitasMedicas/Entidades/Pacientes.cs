using CitasMedicas.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Entidades
{
    public class Paciente
    {
        [Key]
        [PrimeraLetraMayuscula]
        public int Id { get; set; } 

        public string nombre { get; set; }

        public int edad { get; set; }

        public long telefono { get; set; }

        public string email { get; set; }

        public string direccion { get; set; }

        public List<Cita> CitasP { get; set; }
    }
}
