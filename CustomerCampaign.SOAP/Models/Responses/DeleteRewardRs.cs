using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class DeleteRewardRs : ResponseBase
    {
        public DeleteRewardRs(string errorMessage) : base(errorMessage)
        {
        }
    }
}
