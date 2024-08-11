using CsvHelper;
using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Infrastructure;
using CustomerCampaign.Infrastructure.Models.Common;
using CustomerCampaign.SOAP.Helpers;
using CustomerCampaign.SOAP.Interfaces;
using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace CustomerCampaign.SOAP.Services
{
    public class ReportService : IReportService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public ReportService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<WritePurchasesReportRs> WriteCSVPurchasesReportAsync(WritePurchasesReportRq request)
        {
            try
            {
                var validationResult = AuthHelper.ValidateToken(request.AuthToken);

                if(validationResult.Invalid)
                    return new WritePurchasesReportRs(validationResult.Error);

                var purchaseItems = await _purchaseRepository.GetPurchaseItemsAsync();
                var purchaseItemsForReport = ObjectMapper.MapPurchases(purchaseItems);

                var filePath = Path.Combine(
                    Constants.CSV_Destination_Folder,
                    string.Concat(
                        Constants.CSV_File_Name,
                        "_",
                        DateTime.Now.ToString(Constants.CSV_File_Date_Sufix_Format),
                        Constants.CSV_File_Extension));

                Debug.WriteLine("**********************************");
                Debug.WriteLine("CSV FILE LOCATION:");
                Debug.WriteLine(filePath);
                Debug.WriteLine("**********************************");

                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(purchaseItemsForReport);
                }

                return new WritePurchasesReportRs(null);
            }
            catch (Exception)
            {
                return new WritePurchasesReportRs("Unknown error occurred while generating purchase report");
            }
        }

        public async Task<ReadPurchasesReportRs> ReadCSVPurchasesReportAsync(ReadPurchasesReportRq request)
        {
            await Task.Yield();

            var validationResult = AuthHelper.ValidateToken(request.AuthToken);

            if (validationResult.Invalid)
                return new ReadPurchasesReportRs(validationResult.Error);

            try
            {
                var records = new List<PurchaseItem>();

                using (var reader = new StreamReader(new MemoryStream(request.CSVFile), Encoding.UTF8))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                            records = csv.GetRecords<PurchaseItem>().ToList();
                    }
                }

                var response = new ReadPurchasesReportRs(null);
                response.PurchaseItems = records
                    .OrderBy(x => x.PurchaseId)
                    .ThenBy(x => x.PurchaseItemId)
                    .ToList();

                return response;
            }
            catch (Exception)
            {
                return new ReadPurchasesReportRs("Unknown error occurred while generating purchase report");
            }
        }
    }
}
