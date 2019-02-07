using ReportService.ReportGenerator;

namespace ReportService.Models.HtmlToPdf
{
    public class HtmlToPdfRequest
    {
        public Orientation Orientation { get; set; }

        public string HtmlContent { get; set; }
    }
}
