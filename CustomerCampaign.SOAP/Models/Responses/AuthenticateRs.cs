using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class AuthenticateRs : ResponseBase
    {
        public AuthenticateRs(string errorMessage) : base(errorMessage)
        {
        }

        [DataMember]
        public string Token { get; set; }
    }
}
