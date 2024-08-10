namespace CustomerCampaign.Infrastructure.Models.Common
{
    public class Reward
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSsn { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
