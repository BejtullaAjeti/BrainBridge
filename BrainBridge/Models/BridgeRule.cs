namespace BrainBridge.Models
{
    public class BridgeRule
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int BridgeId { get; set; }
        public Bridge Bridge { get; set; } 
    }
}
