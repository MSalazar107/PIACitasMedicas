namespace CitasMedicas.DTO
{
    public class PacienteDTOConCitas: GetPacienteDTO
    {
        public List<CitaDTO> Citas { get; set; }
    }
}
