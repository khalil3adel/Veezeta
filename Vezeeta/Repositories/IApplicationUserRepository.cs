using System.Collections.Generic;
using Vezeeta.Models;
using Vezeeta.ViewModel;

namespace Vezeeta.Repositories
{
    public interface IApplicationUserRepository
    {
        List<UserViewModel> GetUsers();
        //ApplicationUser GetUser(string id);
    }
}