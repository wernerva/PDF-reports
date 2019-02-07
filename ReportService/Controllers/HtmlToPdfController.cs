using Microsoft.AspNetCore.Mvc;
using ReportService.Models.HtmlToPdf;
using ReportService.ReportGenerator;
using System.Threading.Tasks;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HtmlToPdfController : ReportsBaseController
    {
        public HtmlToPdfController(IPdfGenerator pdfGenerator) : base(pdfGenerator) { }

        [HttpPost]
        public async Task<IActionResult> MakePdf([FromBody] HtmlToPdfRequest htmlToPdfRequest)
        {
            var pdfArguments = new PdfArguments("someFileName.pdf")
            {
                Orientation = htmlToPdfRequest.Orientation,
                ViewModel = htmlToPdfRequest.HtmlContent
            };

            var fileData = await PdfGenerator.GeneratePdfAsync(pdfArguments, ControllerContext);

            return Ok(fileData);
        }
    }
}