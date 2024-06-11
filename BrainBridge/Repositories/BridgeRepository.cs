using BrainBridge.Data;
using BrainBridge.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BrainBridge.Repositories
{
    public class BridgeRepository : Repository<Bridge>, IBridgeRepository
    {
        public BridgeRepository(BrainBridgeDbContext context) : base(context)
        {
        }

        public async Task<Bridge> GetByNameAsync(string name)
        {
            return await _context.Bridges.SingleOrDefaultAsync(b => b.Name == name);
        }
    }
}
