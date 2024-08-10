using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class UpdateRewardRs : ResponseBase
    {
        public UpdateRewardRs(string errorMessage) : base(errorMessage)
        {
        }
    }
}