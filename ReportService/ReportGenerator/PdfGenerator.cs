using Microsoft.AspNetCore.Mvc;
using ReportService.Models.Shared;
using Rotativa.AspNetCore;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReportService.ReportGenerator
{
    public class PdfGenerator : IPdfGenerator
    {
        
        public PdfGenerator() { }


        public async Task<FileDataModel> GeneratePdfAsync(PdfArguments pdfArguments, ControllerContext controllerContext)
        {
            var rotativaOrientation = pdfArguments.Orientation == Orientation.Portrait ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape;


            var pdfView = new ViewAsPdf(pdfArguments.ViewModel)
            {
                PageOrientation = rotativaOrientation,
                ContentDisposition = Rotativa.AspNetCore.Options.ContentDisposition.Attachment,
                FileName = $"{Regex.Replace(pdfArguments.FileName, @"\.pdf$", "", RegexOptions.IgnoreCase)}.pdf",
                CustomSwitches = GenerateCustomSwitches(pdfArguments.Header, pdfArguments.Footer),
                PageMargins = GetMargins(pdfArguments.Margins)
            };

            if (!string.IsNullOrWhiteSpace(pdfArguments.ViewName))
            {
                pdfView.ViewName = pdfArguments.ViewName;
            }

            var fileBytes = await pdfView.BuildFile(controllerContext);

            return new FileDataModel
            {
                Base64Data = Convert.ToBase64String(fileBytes),
                ContentType = "application/pdf",
                FileName = pdfView.FileName
            };
        }

        private string GenerateCustomSwitches(PdfHeader header, PdfFooter footer)
        {
            string headerSwitches = header != null ? header.ToString() : "";
            string footerSwitches = footer != null ? footer.ToString() : "";

            return $"{headerSwitches} {footerSwitches}".Trim();
        }

        private Rotativa.AspNetCore.Options.Margins GetMargins(PdfMargins margins)
        {
            if (margins == null)
            {
                return new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0);
            }

            return new Rotativa.AspNetCore.Options.Margins(margins.Top, margins.Right, margins.Bottom, margins.Left);
        }
    }
}
