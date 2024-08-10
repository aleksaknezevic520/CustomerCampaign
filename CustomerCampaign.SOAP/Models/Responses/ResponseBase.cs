using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class ResponseBase
    {
        public ResponseBase(string errorMessage)
        {
            Success = string.IsNullOrEmpty(errorMessage);
            ErrorMessage = errorMessage;
        }

        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
