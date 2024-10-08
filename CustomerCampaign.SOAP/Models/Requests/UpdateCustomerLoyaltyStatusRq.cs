﻿using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class UpdateCustomerLoyaltyStatusRq : RequestBase
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public bool IsLoyal { get; set; }
    }
}
