namespace ReportService.ReportGenerator
{
    public class PdfFooter
    {
        public bool Line { get; set; }

        public string Font { get; set; }

        public int FontSize { get; set; }

        public int Spacing { get; set; }

        public string HtmlSourcePath { get; set; }

        public string Text { get; set; }

        public Alignment TextAlignment { get; set; }
        
        // see https://github.com/worlduniting/bookshop/wiki/wkhtmltopdf-options

        public override string ToString()
        {
            string switches = "";

            if (Line)
            {
                switches += " --footer-line ";
            }

            if (!string.IsNullOrWhiteSpace(Font))
            {
                switches += $" --footer-font-name {Font}";
            }

            if (FontSize > 0)
            {
                switches += $" --footer-font-size {FontSize}";
            }

            if (Spacing > 0)
            {
                switches += $" --footer-spacing {Spacing}";
            }

            if (Spacing > 0)
            {
                switches += $" --footer-spacing {Spacing}";
            }

            if (!string.IsNullOrWhiteSpace(HtmlSourcePath))
            {
                switches += $" --footer-html {HtmlSourcePath}";
            }
            else if (!string.IsNullOrWhiteSpace(Text))
            {
                switch (TextAlignment)
                {
                    case Alignment.Left:
                        switches += $" --footer-left {Text}";
                        break;
                    case Alignment.Right:
                        switches += $" --footer-right {Text}";
                        break;
                    case Alignment.Center:
                    default:
                        switches += $" --footer-center {Text}";
                        break;
                }                
            }

            return switches;
        }
    }
}
