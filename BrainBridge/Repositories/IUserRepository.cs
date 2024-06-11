using BrainBridge.Models;
using System.Threading.Tasks;

namespace BrainBridge.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
