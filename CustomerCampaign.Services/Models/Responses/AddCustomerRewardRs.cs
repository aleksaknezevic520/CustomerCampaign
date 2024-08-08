using System.Runtime.Serialization;

namespace CustomerCampaign.Services.Models.Responses
{
    [DataContract]
    public class AddCustomerRewardRs
    {
        [DataMember]
        public bool SuccessfulSaving { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
