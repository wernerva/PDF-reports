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
        private readonly string _footerSwitch;

        public PdfGenerator()
        {
            _footerSwitch =
                "--footer-right \"Page: [page]/[toPage]\" " +
                "--footer-line --footer-font-size \"6\" " +
                "--footer-spacing 0 --footer-font-name \"Verdana\"";
        }


        public async Task<FileDataModel> GeneratePdfAsync(PdfArguments pdfArguments, ControllerContext controllerContext)
        {
            var rotativaOrientation = pdfArguments.Orientation == Orientation.Portrait ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape;


            var pdfView = new ViewAsPdf(pdfArguments.ViewModel)
            {
                PageOrientation = rotativaOrientation,
                ContentDisposition = Rotativa.AspNetCore.Options.ContentDisposition.Attachment,
                FileName = $"{Regex.Replace(pdfArguments.FileName, @"\.pdf$", "", RegexOptions.IgnoreCase)}.pdf",
                CustomSwitches = _footerSwitch,
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0)
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
    }
}
