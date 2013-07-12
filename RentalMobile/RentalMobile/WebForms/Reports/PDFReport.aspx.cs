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

namespace RentalMobile.Reports
{
    public partial class PdfReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DefaultLcid();
            ////ReportProperties();
            //DownloadPdf();



        }



        public void DefaultLcid()
        {
            if (Session["LCID"] == null)
            {
                Session["LCID"] = 1;
            }
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

        protected void ReportProperties()
        {
            var contractId = GetContractId();
            //ContractIDLabel.Text = Resources.Resource.ContractIDLabel + contractId;
            //Page1();
            //Page2();
            //Page3();
            //Page4();
        }

        protected int GetContractId()
        {
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("~/Home.aspx");
                return 0;
            }
            return int.Parse(Request.QueryString["ID"]);
        }




        protected void OutsideofformButton_Click(object sender, EventArgs e)
        {
            //var test = Request.Url.AbsoluteUri + "?ID=1";
            //Response.Write(test);

            DefaultLcid();
            DownloadPdf();



        }
    }
}