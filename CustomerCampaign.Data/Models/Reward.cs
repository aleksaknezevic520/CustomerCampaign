using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCampaign.Repositories.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal DiscountPercent { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
