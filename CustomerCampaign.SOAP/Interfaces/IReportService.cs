using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;
using System.ServiceModel;

namespace CustomerCampaign.SOAP.Interfaces
{
    [ServiceContract]
    public interface IReportService
    {
        [OperationContract]
        Task<WritePurchasesReportRs> WriteCSVPurchasesReportAsync(WritePurchasesReportRq reqquest);

        [OperationContract]
        Task<ReadPurchasesReportRs> ReadCSVPurchasesReportAsync(ReadPurchasesReportRq request);
    }
}
