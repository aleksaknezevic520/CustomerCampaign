using System.ComponentModel.DataAnnotations;

namespace CustomerCampaign.SOAP.Models.Requests
{
    public class UpdateRewardRq
    {
        [Required]
        public int AgentId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [Range(typeof(decimal), "0", "100")]
        public decimal DiscountPercent { get; set; }
    }
}