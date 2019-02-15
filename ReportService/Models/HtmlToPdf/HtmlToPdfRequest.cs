using ReportService.ReportGenerator;

namespace ReportService.Models.HtmlToPdf
{
    public class HtmlToPdfRequest
    {
        public Orientation Orientation { get; set; }

        public string PdfHeader { get; set; }

        public string PdfBody { get; set; }

        public string PdfFooter { get; set; }

        public PdfMargins Margins { get; set; } = new PdfMargins();
    }
}
