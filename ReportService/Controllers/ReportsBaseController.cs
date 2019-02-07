using ReportService.ReportGenerator;
using Microsoft.AspNetCore.Mvc;

namespace ReportService.Controllers
{
    public abstract class ReportsBaseController : Controller
    {
        public const string PDF_LAYOUT = "_LayoutPdf";
        public const string SCREEN_LAYOUT_LANDSCAPE = "_LayoutScreenLandscape";
        public const string SCREEN_LAYOUT_PORTRAIT = "_LayoutScreenPortrait";

        public ReportsBaseController(IPdfGenerator pdfGenerator)
        {
            PdfGenerator = pdfGenerator;
        }

        protected IPdfGenerator PdfGenerator { get; }
    }
}
