using CustomerCampaign.SOAPConsumer.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<JsonResult> Write() => await _reportFactory.WriteCSVReport();

        [HttpPost]
        [Route(nameof(Read))]
        public async Task<JsonResult> Read([FromForm] IFormFileCollection file) => await _reportFactory.ReadCSVReport(file);
    }
}
