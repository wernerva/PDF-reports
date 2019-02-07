
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

        public object ViewModel { get; set; } = null;

        public string ViewName { get; set; } = null;
    }
}
