﻿using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class AddRewardRs : ResponseBase
    {
        public AddRewardRs(string errorMessage) : base(errorMessage)
        {
        }
    }
}
