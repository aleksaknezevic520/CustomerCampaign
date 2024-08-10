using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class CreateAgentRs : ResponseBase
    {
        public CreateAgentRs(string errorMessage) : base(errorMessage)
        {
        }
    }
}
