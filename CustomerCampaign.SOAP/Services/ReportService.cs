using CsvHelper;
using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Infrastructure;
using CustomerCampaign.Infrastructure.Models.Common;
using CustomerCampaign.SOAP.Helpers;
using CustomerCampaign.SOAP.Interfaces;
using CustomerCampaign.SOAP.Models.Responses;
using System.Diagnostics;
using System.Globalization;

namespace CustomerCampaign.SOAP.Services
{
    public class ReportService : IReportService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public ReportService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<WritePurchasesReportRs> WriteCSVPurchasesReportAsync()
        {
            try
            {
                var purchaseItems = await _purchaseRepository.GetPurchaseItemsAsync();
                var purchaseItemsForReport = ObjectMapper.MapPurchases(purchaseItems);

                var filePath = Path.Combine(Constants.CSV_Write_Destination_Folder, 
                    Constants.CSV_Write_FileName + $"_{DateTime.Now}");

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

        public async Task<ReadPurchasesReportRs> ReadCSVPurchasesReportAsync(Stream file)
        {
            await Task.Yield();

            try
            {
                var reader = new StreamReader(file);
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<PurchaseItem>().ToList();

                reader.Close();
                reader.Dispose();
                csv.Dispose();

                var response = new ReadPurchasesReportRs(null);
                response.PurchaseItems = records;

                return response;
            }
            catch (Exception)
            {
                return new ReadPurchasesReportRs("Unknown error occurred while generating purchase report");
            }
        }
    }
}
