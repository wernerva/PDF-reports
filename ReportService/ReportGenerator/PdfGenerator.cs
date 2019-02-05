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
        public async Task<FileDataModel> GeneratePdfAsync(object viewModel, string fileName, ControllerContext controllerContext)
        {
            var pdfView = new ViewAsPdf(viewModel)
            {
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                ContentDisposition = Rotativa.AspNetCore.Options.ContentDisposition.Attachment,
                FileName = $"{Regex.Replace(fileName, @"\.pdf$", "", RegexOptions.IgnoreCase)}.pdf"
            };

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
