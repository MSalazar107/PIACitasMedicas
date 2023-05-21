using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Entidades
{
    public class Doctores
    {
        [Key]
        public int Id { get; set; }

        public string nombre { get; set; }  

        public string especialidad { get; set; }

        public string consultorio { get; set; }

        public List<Citas> CitasM { get; set; }
    
    }
}
