using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase, IDisposable
    {
        private bool _disposed;
        private IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
            _disposed = false;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<string>> GetRoles()
        {
            return await _roleService.GetAllRoles();
        }

        [Authorize]
        [HttpPost("{name}")]
        public async Task CreateRole(string name)
        {
            await _roleService.CreateRole(name);
        }

        [Authorize]
        [HttpDelete("{name}")]
        public async Task DeleteRole(string name)
        {
            await _roleService.DeleteRole(name);
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
                    _roleService.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
