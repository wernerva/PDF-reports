using Microsoft.AspNetCore.Mvc;
using ReportService.CustomAttributes;
using ReportService.ReportGenerator;
using System.Threading.Tasks;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooReportsController : ReportsBaseController
    {
        public FooReportsController(IPdfGenerator pdfGenerator) : base(pdfGenerator)
        {

        }

        [HttpGet("Landscape")]
        [Layout(SCREEN_LAYOUT_LANDSCAPE)]
        public IActionResult FooReportLandscape()
        {
            return View("FooReport");
        }

        [HttpGet("Portrait")]
        [Layout(SCREEN_LAYOUT_PORTRAIT)]
        public IActionResult FooReportPortrait()
        {
            return View("FooReport");
        }

        [HttpGet("PDF/Landscape")]
        [Layout(PDF_LAYOUT)]
        public async Task<IActionResult> FooReportAsPdfLandscape()
        {
            var pdfArguments = new PdfArguments("someFileName.pdf")
            {
                ViewName = "FooReport",
                Orientation = Orientation.Landscape
            };

            var fileData = await PdfGenerator.GeneratePdfAsync(pdfArguments, ControllerContext);

            return Ok(fileData);
        }

        [HttpGet("PDF/Portrait")]
        [Layout(PDF_LAYOUT)]
        public async Task<IActionResult> FooReportAsPdfPortrait()
        {
            var pdfArguments = new PdfArguments("someFileName.pdf")
            {
                ViewName = "FooReport",
                Orientation = Orientation.Portrait
            };

            var fileData = await PdfGenerator.GeneratePdfAsync(pdfArguments, ControllerContext);

            return Ok(fileData);
        }
    }
}