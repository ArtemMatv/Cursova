using BLL.Models;
using BLL.Models.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<UserModel> GetAsync(string username);
        Task<UserModel> GetAsync(int id);
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel> Register(RegisterModel model);
        Task<UserModel> Authenticate(AuthenticateModel model);
        Task DeleteAccount(string username);
        Task UpdateAccount(UserModel user);
        Task BanUser(string username);
        Task SilenceUser(string username);
        Task ChangeUserRole(string username, string role);
    }
}
