using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.ReportGenerator;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooReportsController : ControllerBase
    {
        private readonly IPdfGenerator _pdfGenerator;

        public FooReportsController(IPdfGenerator pdfGenerator)
        {
            _pdfGenerator = pdfGenerator;
        }

        [HttpGet]
        public async Task<IActionResult> FooReport()
        {
            var fileData = await _pdfGenerator.GeneratePdfAsync(null, "someFileName.pdf", ControllerContext);

            return Ok(fileData);
        }
    }
}