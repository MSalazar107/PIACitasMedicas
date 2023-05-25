using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.DTO
{
    public class AdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
