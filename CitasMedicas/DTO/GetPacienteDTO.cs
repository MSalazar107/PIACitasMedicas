using CitasMedicas.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.DTO
{
    public class GetPacienteDTO
    {
        public int Id { get; set; }

        public string nombre { get; set; }

        public int edad { get; set; }

        public long telefono { get; set; }

        public string email { get; set; }

        public string direccion { get; set; }
       
        public float peso { get; set; }
        
        public float altura { get; set; }
       
        public string hisorialEnfermedades { get; set; }
    }
}
