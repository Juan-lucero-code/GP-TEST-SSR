namespace Gp.Test.Repository
{
    using Gp.Test.Entity;
    using Gp.Test.Interface.Repositories;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;

    public class TestRepository : ITestRepository
    {
        IConfiguration configuration;
        private readonly TestContext _dbContext;

        public TestRepository(TestContext context, IConfiguration configuration)
        {
            _dbContext = context;
            this.configuration = configuration;
        }

        ICollection<Personas>? ITestRepository.GetAll()
        {
            return _dbContext.Personas.ToList();
        }

        Personas? ITestRepository.GetById(Guid id)
        {
            return _dbContext.Personas.Where(x => x.Id == id).FirstOrDefault();
        }

        bool ITestRepository.Update(Personas request)
        {
            var persona = _dbContext.Personas.Where(x => x.Id == request.Id).FirstOrDefault();
            if (persona != null)
            {
                _dbContext.Update(request);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Personas Save(Personas personas)
        {
            _dbContext.Personas.Add(personas);
            _dbContext.SaveChanges();

            return personas;
        }
    }
}