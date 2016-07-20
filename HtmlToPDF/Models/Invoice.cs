using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlToPDF.WebApi.Models
{
    public class Invoice
    {
        public string CSS { get; internal set; }
        public int Id { get; set; }
        public string Number { get; set; }
    }
}