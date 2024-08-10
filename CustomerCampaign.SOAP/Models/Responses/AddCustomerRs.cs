using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class AddCustomerRs : ResponseBase
    {
        public AddCustomerRs(string errorMessage) : base(errorMessage)
        {
        }
    }
}
