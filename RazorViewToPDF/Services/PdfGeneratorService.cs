using HtmlToPDF.RazorViewToPDF.Messaging;
using RazorTemplates.Core;
using System;

namespace HtmlToPDF.RazorViewToPDF.Services
{
    public class PdfGeneratorService
    {
        public generatePDFResponse FromRazorTemplate(string htmlTemplate, object model, bool landscape, int pageMargin)
        {
            var res = new generatePDFResponse();
            string htmlContent;
            try
            {
                var razorTemplate = Template.Compile(htmlTemplate);
                htmlContent = razorTemplate.Render(model);

                res = FromHtml(htmlContent, landscape, pageMargin);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
            }
            return res;
        }

        public generatePDFResponse FromHtml(string htmlContent, bool landscape, int pageMargin)
        {
            var res = new generatePDFResponse();
            try
            {
                var pdfConverter = new NReco.PdfGenerator.HtmlToPdfConverter();
                if (landscape) pdfConverter.Orientation = NReco.PdfGenerator.PageOrientation.Landscape;
                pdfConverter.Margins.Top = pdfConverter.Margins.Right = pdfConverter.Margins.Bottom = pdfConverter.Margins.Left = pageMargin;

                res.PDF = pdfConverter.GeneratePdf(htmlContent);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
            }

            return res;
        }
    }
}
