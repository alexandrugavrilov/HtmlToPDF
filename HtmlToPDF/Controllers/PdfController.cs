using HtmlToPDF.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlToPDF.WebApi.Controllers
{
    public class PdfController : Controller
    {
        // GET: Default
        public ActionResult Preview(string template = "invoice")
        {
            string cssFilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/content/pdf/" + template + ".css");
            string css = System.IO.File.ReadAllText(cssFilePath);

            var model = new Invoice();
            model.Number = "test 123";
            model.CSS = css;

            return View(template, model);
        }
    }
}