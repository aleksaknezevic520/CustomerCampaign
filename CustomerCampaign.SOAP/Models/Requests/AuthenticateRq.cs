using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class AuthenticateRq
    {
        [DataMember]
        [Required]
        public string Email { get; set; }
        
        [Required]
        [DataMember]
        public string Password { get; set; }
    }
}
