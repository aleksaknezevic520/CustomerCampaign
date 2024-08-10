using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CustomerCampaign.SOAPConsumer.Factories
{
    public class ReportFactory
    {
        private readonly ReportServiceClient _reportClient;

        public ReportFactory()
        {
            _reportClient = new ReportServiceClient(ReportServiceClient.EndpointConfiguration.BasicHttpBinding_IReportService);
        }

        internal async Task<JsonResult> WriteCSVReport()
        {
            var response = await _reportClient.WriteCSVPurchasesReportAsync();
            return new JsonResult(response);
        }

        internal async Task<JsonResult> ReadCSVReport(IFormFileCollection file)
        {
            try
            {
                byte[] bytes;
                using (var stream = file[0].OpenReadStream())
                {
                    bytes = new byte[file[0].Length];
                    stream.Read(bytes, 0, (int)file[0].Length);
                }

                var response = await _reportClient.ReadCSVPurchasesReportAsync(bytes);
                return new JsonResult(response);

            }
            catch (Exception)
            {
                return new JsonResult(new { Success = false, Error = "Uploaded file is invalid" });
            }
        }
    }
}
