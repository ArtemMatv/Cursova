using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _repository;
        private bool _disposed;

        public RoleService(IRepository<Role> repository)
        {
            _repository = repository;
            _disposed = false;
        }
        public async Task CreateRole(string name)
        {
            await _repository.InsertAsync(new Role() { Name = name });
        }

        public async Task DeleteRole(string name)
        {
            _repository.Remove(await _repository.GetAsync(r => r.Name == name));
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _repository.GetAllAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _repository.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
