using AutoMapper;
using CitasMedicas.DTO;
using CitasMedicas.Entidades;

namespace CitasMedicas.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DoctorDTO, Doctor>();
            CreateMap<Doctor, GetDoctorDTO>();
            CreateMap<Doctor, DoctorDTOConCitas>()
                .ForMember(doctorDTO => doctorDTO.Citas, opciones => opciones.MapFrom(MapDoctorDTOCitas));
            CreateMap<CitaCreacionDTO, Cita>()
                .ForMember(clase => clase.DoctorCitas, opciones => opciones.MapFrom(MapDoctorCita));
            CreateMap<Cita, CitaDTO>();
            CreateMap<Cita, CitaDTOConDoctor>()
                .ForMember(citaDTO => citaDTO.Doctor, opciones => opciones.MapFrom(MapCitaDTODoctor));
            CreateMap<PacienteDTO, Paciente>();
            CreateMap<Paciente, GetPacienteDTO>();
            CreateMap<Paciente, PacienteDTOConCitas>()
                .ForMember(pacienteDTO => pacienteDTO.Citas, opciones => opciones.MapFrom(MapPacienteDTOCitas));
            //CreateMap<ClasePatchDTO, Clase>().ReverseMap();
            //CreateMap<CursoCreacionDTO, Cursos>();
           // CreateMap<Cursos, CursoDTO>();
        }

        private List<CitaDTO> MapDoctorDTOCitas(Doctor doctor, GetDoctorDTO getDoctorDTO)
        {
            var result = new List<CitaDTO>();

            if (doctor.DoctorCitas == null) { return result; }

            foreach (var doctorCitas in doctor.DoctorCitas)
            {
                result.Add(new CitaDTO()
                {
                    Id = doctorCitas.CitaId,
                    DocId = doctorCitas.Cita.DocId
                });
            }

            return result;
        }

        private List<GetDoctorDTO> MapCitaDTODoctor(Cita cita, CitaDTO citaDTO)
        {
            var result = new List<GetDoctorDTO>();

            if (cita.DoctorCitas == null)
            {
                return result;
            }

            foreach (var doctorCita in cita.DoctorCitas)
            {
                result.Add(new GetDoctorDTO()
                {
                    Id = doctorCita.DoctorId,
                    nombre = doctorCita.Doctor.nombre
                });
            }

            return result;
        }

        private List<DoctorCitas> MapDoctorCita(CitaCreacionDTO citaCreacionDTO, Cita cita)
        {
            var resultado = new List<DoctorCitas>();

            if (citaCreacionDTO.DocId == null) { return resultado; }
            foreach (var doctorId in citaCreacionDTO.DocId)
            {
                resultado.Add(new DoctorCitas() { DoctorId = doctorId });
            }
            return resultado;
        }


        private List<CitaDTO> MapPacienteDTOCitas(Paciente paciente, GetPacienteDTO getPacienteDTO)
        {
            var result = new List<CitaDTO>();

            if (paciente.PacienteCitas == null) { return result; }

            foreach (var pacienteCitas in paciente.PacienteCitas)
            {
                result.Add(new CitaDTO()
                {
                    Id = pacienteCitas.CitaId,
                    PacienteId = pacienteCitas.Cita.PacienteId
                });
            }

            return result;
        }
    }
}

