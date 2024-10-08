﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class CreateAgentRq : RequestBase
    {
        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [DataMember]
        [Required]
        [MinLength(8, ErrorMessage = "Should have at least 8 characters")]
        public string Password { get; set; }
    }
}
