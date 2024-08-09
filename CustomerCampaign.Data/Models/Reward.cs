using System.ComponentModel.DataAnnotations;

namespace CustomerCampaign.Repositories.Models
{
    public class Reward
    {
        public int Id { get; set; }
        [Required]
        public int AgentId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public decimal DiscountPercent { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
