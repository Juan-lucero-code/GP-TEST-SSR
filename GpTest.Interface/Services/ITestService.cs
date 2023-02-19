using Gp.Test.Api.DTO;
using Gp.Test.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gp.Test.Interface.Services
{
    public interface ITestService
    {
        ICollection<PersonasDTO>? GetAll();
        Personas Save(PersonasDTO personas);
        PersonasDTO? GetById(string id);
        bool Update(PersonasDTO personas);
    }
}
