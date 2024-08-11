using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class ReadPurchasesReportRq : RequestBase
    {
        [DataMember]
        public byte[] CSVFile { get; set; }
    }
}
