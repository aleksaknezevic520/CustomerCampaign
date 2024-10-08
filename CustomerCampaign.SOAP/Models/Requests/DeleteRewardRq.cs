﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class DeleteRewardRq : RequestBase
    {
        [Required]
        [DataMember]
        public int AgentId { get; set; }

        [Required]
        [DataMember]
        public int CustomerId { get; set; }
    }
}
