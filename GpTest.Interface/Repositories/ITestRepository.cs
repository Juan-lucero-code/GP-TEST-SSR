using Gp.Test.Entity;

namespace Gp.Test.Interface.Repositories
{
    public interface ITestRepository
    {
        ICollection<Personas>? GetAll();
        Personas Save(Personas personas);
        Personas? GetById (Guid id);
        bool Update (Personas personas);
    }   
}
