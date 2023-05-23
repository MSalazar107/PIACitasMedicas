using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Entidades
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        public string nombre { get; set; }  

        public string especialidad { get; set; }

        public string consultorio { get; set; }

        public List<Cita> CitasM { get; set; }
    
    }
}
