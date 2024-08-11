using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class AddRewardRq : RequestBase
    {
        [Required]
        [DataMember]
        public int AgentId { get; set; }
        [DataMember]
        [Required]
        public int CustomerId { get; set; }
        [DataMember]
        [Required]
        [Range(typeof(decimal), "0", "100")]
        public decimal DiscountPercent { get; set; }
    }
}
