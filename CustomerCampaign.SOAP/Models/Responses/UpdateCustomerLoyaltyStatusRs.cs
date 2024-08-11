using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class UpdateCustomerLoyaltyStatusRs : ResponseBase
    {
        public UpdateCustomerLoyaltyStatusRs(string errorMessage) : base(errorMessage)
        {
        }
    }
}
