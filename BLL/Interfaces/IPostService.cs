using BLL.Models;
using BLL.Models.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPostService
    {
        Task<int> NewPost(NewPostModel model);
        Task DeletePost(int id);
        Task<IEnumerable<PostModel>> GetAllAsync();
        Task<PostModel> GetAsync(int id);
    }
}
