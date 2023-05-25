namespace CitasMedicas.DTO
{
    public class DoctorDTOConCitas: GetDoctorDTO
    {
        public List<CitaDTO> Citas { get; set; }
    }
}
