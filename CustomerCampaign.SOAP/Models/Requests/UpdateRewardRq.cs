using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class UpdateRewardRq : RequestBase
    {
        [Required]
        [DataMember]
        public int AgentId { get; set; }
        [Required]
        [DataMember]
        public int CustomerId { get; set; }
        [Required]
        [DataMember]
        [Range(typeof(decimal), "0", "100")]
        public decimal DiscountPercent { get; set; }
    }
}