using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
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
