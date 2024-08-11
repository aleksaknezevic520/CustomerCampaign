using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class RequestBase
    {
        [DataMember]
        [Required]
        public string AuthToken { get; set; }
    }
}
