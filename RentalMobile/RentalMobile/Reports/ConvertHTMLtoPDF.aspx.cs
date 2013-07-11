using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

public partial class ConvertHTMLtoPDF : System.Web.UI.Page
{
    protected void btnCreatePDF_Click(object sender, EventArgs e)
    {
        // Create a Document object
        var document = new Document(PageSize.A4, 50, 50, 25, 25);

        // Create a new PdfWrite object, writing the output to a MemoryStream
        var output = new MemoryStream();
        var writer = PdfWriter.GetInstance(document, output);

        // Open the Document for writing
        document.Open();

        // Read in the contents of the Receipt.htm HTML template file
        string contents = File.ReadAllText(Server.MapPath("~/HTMLTemplate/Receipt.htm"));

        // Replace the placeholders with the user-specified text
        contents = contents.Replace("[ORDERID]", txtOrderID.Text);
        contents = contents.Replace("[TOTALPRICE]", Convert.ToDecimal(txtTotalPrice.Text).ToString("c"));
        contents = contents.Replace("[ORDERDATE]", DateTime.Now.ToShortDateString());

        var itemsTable = @"<table><tr><th style=""font-weight: bold"">Item #</th><th style=""font-weight: bold"">Item Name</th><th style=""font-weight: bold"">Qty</th></tr>";
        foreach (System.Web.UI.WebControls.ListItem item in cblItemsPurchased.Items)
            if (item.Selected)
            {
                // Each CheckBoxList item has a value of ITEMNAME|ITEM#|QTY, so we split on | and pull these values out...
                var pieces = item.Value.Split("|".ToCharArray());
                itemsTable += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
                                            pieces[1], pieces[0], pieces[2]);
            }
        itemsTable += "</table>";

        contents = contents.Replace("[ITEMS]", itemsTable);


        var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(contents), null);
        foreach (var htmlElement in parsedHtmlElements)
            document.Add(htmlElement as IElement);



        // You can add additional elements to the document. Let's add an image in the upper right corner
        var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/4guysfromrolla.gif"));
        logo.SetAbsolutePosition(440, 800);
        document.Add(logo);

        document.Close();

        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Receipt-{0}.pdf", txtOrderID.Text));
        Response.BinaryWrite(output.ToArray());
    }
}