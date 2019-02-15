namespace ReportService.ReportGenerator
{
    public class PdfMargins
    {
        public int Top { get; set; } = 10;

        public int Right { get; set; } = 10;

        public int Bottom { get; set; } = 10;

        public int Left { get; set; } = 10;

        public PdfMargins() { }

        public PdfMargins(int top, int right, int bottom, int left) {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }
    }
}
