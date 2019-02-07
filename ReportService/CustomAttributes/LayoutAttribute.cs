using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ReportService.CustomAttributes
{
    public class LayoutAttribute: ResultFilterAttribute, IResultFilter
    {
        private readonly string _layout;

        public LayoutAttribute(string layout)
        {
            if (string.IsNullOrWhiteSpace(layout))
            {
                throw new ArgumentException("Invalid layout.");
            }

            _layout = layout;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var viewResult = context.Result as ViewResult;
            if (viewResult != null)
            {
                viewResult.ViewData["Layout"] = _layout;
            }
        }
    }
}
