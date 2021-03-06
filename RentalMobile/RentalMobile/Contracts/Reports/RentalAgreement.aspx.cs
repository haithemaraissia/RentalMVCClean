﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using RentalMobile.Model.Models;

namespace RentalMobile.Contracts.Reports
{
    public partial class RentalAgreement : System.Web.UI.Page
    {    
        public RentalContext db = new RentalContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetContract();
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

        protected void GetContract()
        {
          
            var contract = db.GeneratedRentalContracts.FirstOrDefault(x => x.ID == 1);
            if (contract != null)
            {
                LeaseNumber.Text = contract.ID.ToString(CultureInfo.InvariantCulture);
                Owner.Text = contract.LandLoardName;
                Lesser.Text = contract.TenantName;
                PropertyStreetLabel.Text = contract.PropertyAddress;
                PropertyCity.Text = contract.PropertyCity;
                if (contract.MonthlyRent != null)
                    MonthlyRent.Text = contract.MonthlyRent.Value.ToString(CultureInfo.InvariantCulture);
                if (contract.BeginingDate != null) BeginingDate.Text = contract.BeginingDate.ToString();
                if (contract.StartDate != null) StartDate.Text = contract.StartDate.Value.ToShortTimeString();
                if (contract.EndDate != null) EndDate.Text = contract.EndDate.Value.ToShortTimeString();
                if (contract.FirstMonthRent != null) FirstMonthRent.Text = contract.FirstMonthRent.Value.ToString(CultureInfo.InvariantCulture);
                if (contract.SecurityDeposit != null) SecurityDeposit.Text = contract.SecurityDeposit.Value.ToString(CultureInfo.InvariantCulture);
                if (contract.TotalPayment != null) TotalPayment.Text = contract.TotalPayment.Value.ToString(CultureInfo.InvariantCulture);
                OwnerPayableName.Text = contract.LandLoardName;
                if (contract.TenantRefundedNumberofDays != null)
                    TenantRefundedNumberofDays.Text = contract.TenantRefundedNumberofDays.Value.ToString(CultureInfo.InvariantCulture);
                if (contract.NoticeofMoveoutNumberofDays != null)
                    NoticeofMoveOutNumberofDays.Text = contract.NoticeofMoveoutNumberofDays.Value.ToString(CultureInfo.InvariantCulture);
                if (contract.LateFeeCharge != null)
                    LateFeeCharge.Text = contract.LateFeeCharge.Value.ToString(CultureInfo.InvariantCulture);

                if (contract.PercentageofLateFeeCharge != null)
                    PercentageofLateFeeCharge.Text = contract.PercentageofLateFeeCharge.Value.ToString(CultureInfo.InvariantCulture);


//FifthDay
                if (contract.ExceptedUtilites != null) PaidUtilities.Text = contract.ExceptedUtilites.ToString(CultureInfo.InvariantCulture);
                if (contract.PetDeposit != null) PetDeposit.Text = contract.PetDeposit.Value.ToString(CultureInfo.InvariantCulture);
                if (contract.PetMonthly != null) PetMonthly.Text = contract.PetMonthly.Value.ToString(CultureInfo.InvariantCulture);
                if (contract.ParkingSpaceNumber != null) ParkingSpaceNumber.Text = contract.ParkingSpaceNumber.ToString(CultureInfo.InvariantCulture);
                if (contract.ParkingFee != null) Parkingfee.Text = contract.ParkingFee.Value.ToString(CultureInfo.InvariantCulture);
                if (contract.LandLoardAddress != null) OwnerEntireAddress.Text = contract.LandLoardAddress;
            }

//ParkingSpaceNumber
//Parkingfee
//OwnerEntireAddress
        }
    }
}