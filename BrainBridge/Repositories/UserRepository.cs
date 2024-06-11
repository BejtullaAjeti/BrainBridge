using BrainBridge.Data;
using BrainBridge.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BrainBridge.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BrainBridgeDbContext context) : base(context)
        {
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
