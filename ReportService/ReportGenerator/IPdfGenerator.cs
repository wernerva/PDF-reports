using Microsoft.AspNetCore.Mvc;
using ReportService.Models.Shared;
using System.Threading.Tasks;

namespace ReportService.ReportGenerator
{
    public interface IPdfGenerator
    {
        Task<FileDataModel> GeneratePdfAsync(object viewModel, string fileName, ControllerContext controllerContext);
    }
}
