using System.ComponentModel.DataAnnotations;

namespace CustomerCampaign.SOAP.Models.Requests
{
    public class AddCustomerRewardRq
    {
        [Required]
        public int AgentId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public decimal DiscountPercent { get; set; }
    }
}
