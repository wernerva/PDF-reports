namespace ReportService.ReportGenerator
{
    public class PdfHeader
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
                switches += " --header-line ";
            }

            if (!string.IsNullOrWhiteSpace(Font))
            {
                switches += $" --header-font-name {Font}";
            }

            if (FontSize > 0)
            {
                switches += $" --header-font-size {FontSize}";
            }

            if (Spacing > 0)
            {
                switches += $" --header-spacing {Spacing}";
            }

            if (Spacing > 0)
            {
                switches += $" --header-spacing {Spacing}";
            }

            if (!string.IsNullOrWhiteSpace(HtmlSourcePath))
            {
                switches += $" --header-html {HtmlSourcePath}";
            }

            else if (!string.IsNullOrWhiteSpace(Text))
            {
                switch (TextAlignment)
                {
                    case Alignment.Left:
                        switches += $" --header-left \"{Text}\"";
                        break;
                    case Alignment.Right:
                        switches += $" --header-right \"{Text}\"";
                        break;
                    case Alignment.Center:
                    default:
                        switches += $" --header-center \"{Text}\"";
                        break;
                }                
            }

            return switches;
        }
    }
}
