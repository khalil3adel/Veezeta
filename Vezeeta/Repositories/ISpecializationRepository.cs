using System.Collections.Generic;
using Vezeeta.Models;

namespace Vezeeta.Repositories
{
    public interface ISpecializationRepository
    {
        IEnumerable<Specialty> GetSpecializations();
    }
}
