
namespace ReportService.ReportGenerator
{
    public class PdfArguments
    {
        public PdfArguments(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; set; }

        public Orientation Orientation { get; set; } = Orientation.Portrait;

        public object ViewModel { get; set; }

        public string ViewName { get; set; }

        public PdfHeader Header { get; set; }

        public PdfFooter Footer { get; set; }

        public int FooterHeight { get; set; }

        public PdfMargins Margins { get; set; } = new PdfMargins();
    }
}
