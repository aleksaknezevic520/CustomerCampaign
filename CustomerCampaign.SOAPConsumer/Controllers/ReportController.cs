using CustomerCampaign.SOAPConsumer.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService;
using System.Threading.Tasks;

namespace CustomerCampaign.SOAPConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportFactory _reportFactory;

        public ReportController(ReportFactory reportFactory)
        {
            _reportFactory = reportFactory;
        }

        [HttpPost]
        [Route(nameof(Write))]
        public async Task<JsonResult> Write([FromBody] WritePurchasesReportRq rq) => 
            await _reportFactory.WriteCSVReport(rq);

        [HttpPost]
        [Route(nameof(Read))]
        public async Task<JsonResult> Read([FromForm] IFormFileCollection file, string authToken) => 
            await _reportFactory.ReadCSVReport(file, authToken);
    }
}
