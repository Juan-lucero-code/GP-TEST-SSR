using Gp.Test.Entity;

namespace Gp.Test.Api.DTO.Mappers
{
    public class PersonasMapper
    {
        public PersonasDTO MapToDto(Personas persona)
        {
            return new PersonasDTO
            {
                Id = persona.Id,
                NombreCompleto = persona.NombreCompleto ?? "",
                Edad = persona.Edad ?? "",
                Domicilio = persona.Domicilio ?? "",
                Telefono = persona.Telefono ?? "",
                Profesion = persona.Profesion ?? ""
            };
        }

        public IEnumerable<PersonasDTO> MapManyToDto(IEnumerable<Personas> personas)
        {
            return personas.Select(persona => new PersonasDTO
            {
                Id = persona.Id,
                NombreCompleto = persona.NombreCompleto ?? "",
                Edad = persona.Edad ?? "",
                Domicilio = persona.Domicilio ?? "",
                Telefono = persona.Telefono ?? "",
                Profesion = persona.Profesion ?? ""
            });
        }

        public Personas MapFromDto(PersonasDTO personasDto)
        {
            return new Personas
            {
                Id = personasDto.Id,
                NombreCompleto = personasDto.NombreCompleto,
                Edad = personasDto.Edad,
                Domicilio = personasDto.Domicilio,
                Telefono = personasDto.Telefono,
                Profesion = personasDto.Profesion,
            };
        }
    }
}
