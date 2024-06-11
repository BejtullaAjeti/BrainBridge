using BrainBridge.Data;
using BrainBridge.Models;

namespace BrainBridge.Repositories
{
    public class BridgeRuleRepository : Repository<BridgeRule>, IBridgeRuleRepository
    {
        public BridgeRuleRepository(BrainBridgeDbContext context) : base(context)
        {
        }
    }
}
