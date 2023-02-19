using AutoMapper;
using Gp.Test.Api.DTO;
using Gp.Test.Api.DTO.Mappers;
using Gp.Test.Entity;
using Gp.Test.Interface.Repositories;
using Gp.Test.Interface.Services;
using Microsoft.Graph;

namespace Service
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _repository;
        private readonly PersonasMapper _mapper;
        public TestService(ITestRepository repository, PersonasMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICollection<PersonasDTO>? GetAll()
        {
            var personas = _repository.GetAll();
            if (personas == null) return null;

            return _mapper.MapManyToDto(personas).ToList();
        }

        public PersonasDTO? GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Parameter Id should not be null");

            var persona = _repository.GetById(new Guid(id));
            if (persona == null) return null;

            return _mapper.MapToDto(persona);
        }

        public Personas Save(PersonasDTO request)
        {

            var persona = _mapper.MapFromDto(request);
            return _repository.Save(persona);
        }

        public bool Update(PersonasDTO request)
        {
            if (request == null) return false;
            var persona = _repository.GetById(request.Id);
            if (persona == null) return false;

            persona.Profesion = request.Profesion;
            persona.NombreCompleto = request.NombreCompleto;
            persona.Domicilio = request.Domicilio;
            persona.Edad = request.Edad;
            persona.Telefono = request.Telefono;

            return _repository.Update(persona);
        }
    }
}