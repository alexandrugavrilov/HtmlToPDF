# HtmlToPDF
<h2>The solution uses: </h2>
<ul>
<li><a href="http://www.nrecosite.com/pdf_generator_net.aspx">Nreco pdf generator</a> based on WkHtmlToPdf for generating PDF</li>
<li><a href="https://github.com/volkovku/RazorTemplates">RazorTemplates</a> for generating HTML using the .net Razor engine</li>
</ul>

<p>Solution consists of 2 projects</p>
<ol>
<li>
  <h3>RazorViewToPDF project</h3> that exposes :
  <ul>
    <li>PdfGeneratorService.FromRazorTemplate() that receives the html of a razor view, compiles it and sends it to</li>
    <li>PdfGeneratorService.FromHtml() that sends it to the NReco.PdfGenerator that generates the pdf</li>
  </ul>
</li>
<li>
  <h3>WebApi project</h3>
  which can be used for creating the razor views, and testing them with
  <ul>
    <li><strong>PdfController</strong> (MVC controller) -> uses Views/Pdf</li>
    <li><strong>GeneratePDFController</strong> (WebApi controller) -> uses the class library RazorViewToPDF to generate pdfs</li>
    </li>
  </ul>
</li>
</ol>
  
[![Book session on Codementor](https://cdn.codementor.io/badges/book_session_github.svg)](https://www.codementor.io/alexandrugavrilov?utm_source=github&utm_medium=button&utm_term=alexandrugavrilov&utm_campaign=github)
