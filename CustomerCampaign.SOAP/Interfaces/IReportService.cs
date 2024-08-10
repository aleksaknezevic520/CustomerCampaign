using CustomerCampaign.SOAP.Models.Responses;
using System.ServiceModel;

namespace CustomerCampaign.SOAP.Interfaces
{
    [ServiceContract]
    public interface IReportService
    {
        [OperationContract]
        Task<WritePurchasesReportRs> WriteCSVPurchasesReportAsync();

        [OperationContract]
        Task<ReadPurchasesReportRs> ReadCSVPurchasesReportAsync(byte[] file);
    }
}
