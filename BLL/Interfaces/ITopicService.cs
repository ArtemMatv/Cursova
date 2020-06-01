using BLL.Models;
using BLL.Models.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITopicService
    {
        Task<TopicModel> GetAsync(int id);
        Task<IEnumerable<TopicModel>> GetAllAsync();
        Task CreateTopic(string name);
        Task DeleteTopic(int id);
    }
}
