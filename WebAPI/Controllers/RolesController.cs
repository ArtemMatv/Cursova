using BLL.Exceptions;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("4tZCduV.7-nlTy6x/[controller]")]
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

        [HttpGet]
        public async Task<IEnumerable<string>> GetRoles()
        {
            return await _roleService.GetAllRoles();
        }

        [Authorize]
        [HttpPost("{name}")]
        public async Task<IActionResult> CreateRole(string name)
        {
            await _roleService.CreateRole(name);

            return Ok();
        }

        [Authorize]
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteRole(string name)
        {
            try
            {
                await _roleService.DeleteRole(name);
            }
            catch(DataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
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
