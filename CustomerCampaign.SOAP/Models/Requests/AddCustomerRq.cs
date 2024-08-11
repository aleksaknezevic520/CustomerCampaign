using CustomerCampaign.Infrastructure.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class AddCustomerRq : RequestBase
    {
        [DataMember]
        [Required]
        public string Name { get; set; }
        [DataMember]
        [Required]
        public string SSN { get; set; }
        [DataMember]
        public DateTime? DateOfBirth { get; set; }
        [DataMember]
        public Address HomeAddress { get; set; }
        [DataMember]
        public Address WorkAddress { get; set; }
    }
}
