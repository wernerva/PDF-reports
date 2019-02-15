using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ReportService.Models.HtmlToPdf;
using ReportService.ReportGenerator;
using System;
using System.Threading.Tasks;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HtmlToPdfController : ReportsBaseController
    {
        private IMemoryCache _cache;
        private string _controllerName;

        private string ControllerName
        {
            get
            {
                if (_controllerName == null)
                {
                    _controllerName = this.RouteData.Values["controller"].ToString();
                }

                return _controllerName;
            }
        }

        public HtmlToPdfController(IPdfGenerator pdfGenerator, IMemoryCache cache) : base(pdfGenerator) {
            _cache = cache;
        }


        [HttpPost("preview")]
        public IActionResult PreviewPdf([FromBody] HtmlToPdfRequest htmlToPdfRequest)
        {
            ViewData["Layout"] = htmlToPdfRequest.Orientation == Orientation.Landscape ? SCREEN_LAYOUT_LANDSCAPE : SCREEN_LAYOUT_PORTRAIT;

            return View(htmlToPdfRequest);
        }

        [HttpPost]
        public async Task<IActionResult> MakePdf([FromBody] HtmlToPdfRequest htmlToPdfRequest)
        {
            var cacheId = Guid.NewGuid();

            var pdfArguments = new PdfArguments("someFileName.pdf")
            {
                Orientation = htmlToPdfRequest.Orientation,
                ViewModel = htmlToPdfRequest.PdfBody,
                Margins = htmlToPdfRequest.Margins
            };

            if (!string.IsNullOrWhiteSpace(htmlToPdfRequest.PdfHeader))
            {
                CacheHeader(cacheId, htmlToPdfRequest.PdfHeader);
                pdfArguments.Header = new PdfHeader() { HtmlSourcePath = Url.Action(nameof(GetHeader), ControllerName, new { cacheId = cacheId }, Request.Scheme) };
            }

            if (!string.IsNullOrWhiteSpace(htmlToPdfRequest.PdfFooter))
            {

                CacheFooter(cacheId, htmlToPdfRequest.PdfFooter);
                pdfArguments.Footer = new PdfFooter() { HtmlSourcePath = Url.Action(nameof(GetFooter), ControllerName, new { cacheId = cacheId }, Request.Scheme) };
            }

            var fileData = await PdfGenerator.GeneratePdfAsync(pdfArguments, ControllerContext);

            return Ok(fileData);
        }

        [HttpGet("pdfHeader")]
        public IActionResult GetHeader(Guid cacheId)
        {
            var header = "";

            _cache.TryGetValue($"{cacheId}_header", out header);

            return View("HeaderFooter", header);
        }

        [HttpGet("pdfFooter")]
        public IActionResult GetFooter(Guid cacheId)
        {
            var footer = "";

            _cache.TryGetValue($"{cacheId}_footer", out footer);

            return View("HeaderFooter", footer);
        }

        private void CacheHeader(Guid id, string header)
        {
            _cache.Set($"{id}_header", header);
        }

        private void CacheFooter(Guid id, string footer)
        {
            _cache.Set($"{id}_footer", footer);
        }
    }
}