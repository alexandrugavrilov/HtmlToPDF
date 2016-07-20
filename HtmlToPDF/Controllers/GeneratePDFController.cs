using HtmlToPDF.WebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HtmlToPDF.WebApi.Controllers
{
    [RoutePrefix("api/GeneratePDF")]
    public class GeneratePDFController : ApiController
    {
        [HttpGet]
        [Route("generate/{template}")]
        public HttpResponseMessage Generate(string template)
        {
            string invoiceFilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/views/pdf/"+ template + ".cshtml");
            string invoiceHtml = File.ReadAllText(invoiceFilePath);
            string cssFilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/content/pdf/" + template + ".css");
            string css = File.ReadAllText(cssFilePath);

            var pdfService = new RazorViewToPDF.Services.PdfGeneratorService();
            var invoice = new Invoice() { Number = "abc 123", CSS = css };
            var res = pdfService.FromRazorTemplate(invoiceHtml, invoice, landscape: false, pageMargin: 0);

            // Serve the file to the client
            HttpResponseMessage result;           

            if (string.IsNullOrEmpty(res.ErrorMessage))
            {
                result = Request.CreateResponse(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(res.PDF);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = template + ".pdf";
                return result;
            }
            else {
                result = Request.CreateResponse(HttpStatusCode.InternalServerError);
                result.StatusCode = HttpStatusCode.NotFound;
                result.ReasonPhrase = res.ErrorMessage;
                return result;
            }
        }
    }
}
