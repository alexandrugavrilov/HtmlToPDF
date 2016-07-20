using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlToPDF.RazorViewToPDF.Messaging
{
    public class generatePDFResponse
    {
        public string ErrorMessage { get; internal set; }
        public byte[] PDF { get; internal set; }
    }
}
