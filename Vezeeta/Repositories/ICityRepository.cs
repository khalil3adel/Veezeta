using System.Collections.Generic;
using Vezeeta.Models;

namespace Vezeeta.Repositories
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCities();
    }
}