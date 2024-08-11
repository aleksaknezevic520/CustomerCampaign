using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService;
using System;
using System.Threading.Tasks;

namespace CustomerCampaign.SOAPConsumer.Factories
{
    public class ReportFactory
    {
        private readonly ReportServiceClient _reportClient;

        public ReportFactory(ReportServiceClient reportClient)
        {
            _reportClient = reportClient;
        }

        internal async Task<JsonResult> WriteCSVReport(WritePurchasesReportRq rq)
        {
            var response = await _reportClient.WriteCSVPurchasesReportAsync(rq);
            return new JsonResult(response);
        }

        internal async Task<JsonResult> ReadCSVReport(IFormFileCollection file, string authToken)
        {
            if(string.IsNullOrEmpty(authToken))
                return new JsonResult(new { Success = false, Error = "Not authenticated" });

            try
            {
                byte[] bytes;
                using (var stream = file[0].OpenReadStream())
                {
                    bytes = new byte[file[0].Length];
                    stream.Read(bytes, 0, (int)file[0].Length);
                }

                var response = await _reportClient.ReadCSVPurchasesReportAsync(new ReadPurchasesReportRq
                {
                    AuthToken = authToken,
                    CSVFile = bytes
                });

                return new JsonResult(response);

            }
            catch (Exception)
            {
                return new JsonResult(new { Success = false, Error = "Uploaded file is invalid" });
            }
        }
    }
}
