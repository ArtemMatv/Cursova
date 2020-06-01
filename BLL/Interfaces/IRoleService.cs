using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoleService : IDisposable
    {
        Task CreateRole(string name);

        Task DeleteRole(string name);
        Task<IEnumerable<Role>> GetAllRoles();
    }
}
