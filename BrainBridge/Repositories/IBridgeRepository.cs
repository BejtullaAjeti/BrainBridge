using BrainBridge.Models;
using System.Threading.Tasks;

namespace BrainBridge.Repositories
{
    public interface IBridgeRepository : IRepository<Bridge>
    {
        Task<Bridge> GetByNameAsync(string name);
    }
}
