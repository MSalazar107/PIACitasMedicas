using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Entidades
{
    public class Pacientes
    {
        [Key]
        public int Id { get; set; } 

        public string nombre { get; set; }

        public long telefono { get; set; }

        public string email { get; set; }

        public string direccion { get; set; }

        public List<Citas> CitasP { get; set; }
    }
}
