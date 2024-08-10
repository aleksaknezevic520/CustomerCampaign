using System.ComponentModel.DataAnnotations;

namespace CustomerCampaign.SOAP.Models.Requests
{
    public class DeleteRewardRq
    {
        [Required]
        public int AgentId { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
