using BLL.Exceptions;
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
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteRole(string name)
        {
            var role = await _repository.GetAsync(r => r.Name == name);

            if (role == null)
                throw new DataException($"There is no \"{name}\" role!");

            _repository.Remove(role);

            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> GetAllRoles()
        {
            var roles = await _repository.GetAllAsync();
            List<string> result = new List<string>();

            foreach(var item in roles)
            {
                result.Add(item.Name);
            }

            return result;
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
