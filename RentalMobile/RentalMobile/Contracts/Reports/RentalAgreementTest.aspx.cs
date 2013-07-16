using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace RentalMobile.Contracts.Reports
{
    public partial class RentalAgreementTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           DownloadPdf();
        }

        protected void DownloadPdf()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            var reportstringwriter = new StringWriter();
            var reporthtmlwriter = new HtmlTextWriter(reportstringwriter);
            var pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
            var htmlparser = new HTMLWorker(pdfDoc);

            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            Report.RenderControl(reporthtmlwriter);
            var reportstring = reportstringwriter.ToString();
            var reportstringreader = new StringReader(reportstring);

            pdfDoc.Open();
            htmlparser.Parse(reportstringreader);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}