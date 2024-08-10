﻿namespace CustomerCampaign.Repositories.Models
{
    public class Reward
    {
        public int AgentId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal DiscountPercent { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
