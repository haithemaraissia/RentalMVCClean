<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentalAgreement.aspx.cs"
    Inherits="RentalMobile.Contracts.Reports.RentalAgreement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .left
        {
            text-align: left;
        }
        .center
        {
            text-align: center;
        }
        .style1
        {
            color: #003300;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Report" runat="server">
        <table width="735" cellspacing="0" cellpadding="0" border="0">
            <tr>
                <td valign="TOP">
                    <p>
                        <table width="90%" style="font-family: Arial">
                            <tr>
                                <td>
                                    <div style="text-align: center;">
                                        <h2>
                                            <b>LEASE #  <asp:Label ID="LeaseNumber" runat="server" Text="123" ForeColor="Red"></asp:Label></b>
                                        </h2>
                                    </div>
                                    <br />
                                    <div style="text-align: center;">
                                        <h3>
                                            <b>BASIC RENTAL AGREEMENT OR RESIDENTIAL LEASE<br>
                                            </b>
                                        </h3>
                                    </div>
                                    <br />
                                    This Rental Agreement or Residential Lease shall evidence the complete terms and
                                    conditions under which the parties whose signatures appear below have agreed. Landlord/Lessor/Agent,
                                    <asp:Label ID="Owner" runat="server" Text="_____________________________" ForeColor="Red"></asp:Label>,
                                    shall be referred to as "OWNER" and Tenant(s)/Lessee,
                                    <asp:Label ID="Lesser" runat="server" Text="_____________________________" ForeColor="Red"></asp:Label>,
                                    shall be referred to as "RESIDENT." As consideration for this agreement, OWNER agrees
                                    to rent/lease to RESIDENT and RESIDENT agrees to rent/lease from OWNER for use solely
                                    as a private residence, the premises located at
                                    <asp:Label ID="PropertyStreetLabel" runat="server" Text="_____________________________"
                                        ForeColor="Red"></asp:Label>
                                    &nbsp;in the city of&nbsp;
                                    <asp:Label ID="PropertyCity" runat="server" Text="_____________________________"
                                        ForeColor="Red"></asp:Label>.<p>
                                            <br />
                                            1. <b>TERMS:</b> RESIDENT agrees to pay in advance $
                                            <asp:Label ID="MonthlyRent" runat="server" Text="______" ForeColor="Red"></asp:Label>&nbsp;per
                                            month on the
                                           <asp:Label ID="BeginingDate" runat="server" Text="____" ForeColor="Red"></asp:Label>
                                             &nbsp;day of each month. This agreement shall commence on
                                            <asp:Label ID="StartDate" runat="server" Text="______" ForeColor="Red"></asp:Label>
                                            &nbsp;and continue until
                                            <asp:Label ID="EndDate" runat="server" Text="______" ForeColor="Red"></asp:Label>&nbsp;as
                                            a leasehold. Thereafter it shall become a month-to-month tenancy. If RESIDENT should
                                            move from the premises prior to the expiration of this time period, he shall be
                                            liable for all rent due until such time that the Residence is occupied by an OWNER
                                            approved paying RESIDENT and/or expiration of said time period, whichever is shorter.<br>
                                            <br />
                                            <p>
                                                2. <b>PAYMENTS:</b> Rent and/or other charges are to be paid at such place or method
                                                designated by the owner as follows. All payments are to be made by check or money
                                                order or by credit card through
                                                <asp:Label ID="SiteNameLabel" runat="server" Text="Myside.com" ForeColor="Red" />
                                                . OWNER acknowledges receipt of the First Month's rent of $<asp:Label ID="FirstMonthRent"
                                                    runat="server" Text="__________" ForeColor="Red" />, and a Security Deposit
                                                of $<asp:Label ID="SecurityDeposit" runat="server" Text="__________" ForeColor="Red" />,
                                                for a total payment of $<asp:Label ID="TotalPayment" runat="server" Text="__________"
                                                    ForeColor="Red" />. All payments are to be made payable to&nbsp;<asp:Label ID="OwnerPayableName"
                                                        runat="server" Text="__________________________________ " ForeColor="Red" />.</p>
                                            <br />
                                            <p>
                                                3. <b>MAINTENANCE PROVIDER :</b> RESIDENT Should be subscribed to receive monthly
                                                maitenance coverage by at least 1 maintenance provider provided in
                                                <asp:Label ID="SiteNameLabel2" runat="server" Text="Myside.com" ForeColor="Red" />
                                                . Any violations will result in the dissemation of this contract.
                                            </p>
                                            <br />
                                            <p>
                                                4. <b>SECURITY DEPOSITS:</b> The total of the above deposits shall secure compliance
                                                with the terms and conditions of this agreement and shall be refunded to RESIDENT
                                                within
                                                <asp:Label ID="TenantRefundedNumberofDays" runat="server" Text="8" ForeColor="Red" />&nbsp;days
                                                after the premises have been completely vacated less any amount necessary to pay
                                                OWNER; a) any unpaid rent, b) cleaning costs, c) key replacement costs, d) cost
                                                for repair of damages to premises and/or common areas above ordinary wear and tear,
                                                and e) any other amount legally allowable under the terms of this agreement. A written
                                                accounting of said charges shall be presented to RESIDENT within
                                                <asp:Label ID="NoticeofMoveOutNumberofDays" runat="server" Text="2" ForeColor="Red" />
                                                &nbsp;days of move-out. If deposits do not cover such costs and damages, the RESIDENT
                                                shall immediately pay said additional costs for damages to OWNER.
                                            </p>
                                            <br />
                                            <p>
                                                5. <b>LATE CHARGE:</b> A late fee of $
                                                <asp:Label ID="LateFeeCharge" runat="server" Text="25" ForeColor="Red" />, (not
                                                to exceed
                                                <asp:Label ID="PercentageofLateFeeCharge" runat="server" Text="25" ForeColor="Red" />%
                                                of the monthly rent), shall be added and due for any payment of rent made after
                                                the
                                                <asp:Label ID="FifthDay" runat="server" Text="fifth" ForeColor="Red" />
                                                &nbsp;of the month. Any dishonored check shall be treated as unpaid rent, and subject
                                                to an additional fee of $<asp:Label ID="CheckFee" runat="server" Text="35" ForeColor="Red" />.
                                            </p>
                                            <br />
                                            <p>
                                                6. <b>UTILITIES:</b> RESIDENT agrees to pay all utilities and/or services based
                                                upon occupancy of the premises except
                                                <asp:Label ID="PaidUtilities" runat="server" Text="____________________________________"
                                                    ForeColor="Red" />.</p>
                                            <br />
                                            <p>
                                                7. <b>OCCUPANTS:</b> Guest(s) staying in the rental for more than 7 consecutive
                                                days, or a total of over 20 days in any 12 month period, is considered a resident.
                                                If done so without the written consent of OWNER shall be considered a breach of
                                                this agreement. ONLY the following individuals and/or animals, AND NO OTHERS shall
                                                occupy the subject residence for more than 20 days unless the expressed written
                                                consent of OWNER obtained in advance.
                                            </p>
                                            <br />
                                            <p>
                                                8. <b>PETS:</b> No animal, fowl, fish, reptile, and/or pet of any kind shall be
                                                kept on or about the premises, for any amount of time, without obtaining the prior
                                                written consent and meeting the requirements of the OWNER. Such consent if granted,
                                                shall be revocable at OWNER'S option upon giving a 30 day written notice. In the
                                                event laws are passed or permission is granted to have a pet and/or animal of any
                                                kind, an additional deposit in the amount of $<asp:Label ID="PetDeposit" runat="server"
                                                    Text="400"></asp:Label>
                                                shall be required along with additional monthly rent of $<asp:Label ID="PetMonthly"
                                                    runat="server" Text="25"></asp:Label>
                                                along with the signing of OWNER'S Pet Agreement. RESIDENT also agrees to carry insurance
                                                deemed appropriate by OWNER to cover possible liability and damages that may be
                                                caused by such animals.</p>
                                            <br />
                                            <p>
                                                9. <b>LIQUID FILLED FURNISHINGS:</b> No liquid filled furniture, receptacle containing
                                                more than ten gallons of liquid is permitted without prior written consent and meeting
                                                the requirements of the OWNER. RESIDENT also agrees to carry insurance deemed appropriate
                                                by OWNER to cover possible losses that may be caused by such items.</p>
                                            <br />
                                            <p>
                                                10. <b>PARKING:</b> When and if RESIDENT is assigned a parking area/space on OWNER'S
                                                property, the parking area/space shall be used exclusively for parking of passenger
                                                automobiles and/or those approved vehicles listed on RESIDENT'S Application attached
                                                hereto. RESIDENT is hereby assigned or permitted to park only in the following area
                                                or space
                                                <asp:Label ID="ParkingSpaceNumber" runat="server" Text="___" ForeColor="Red"></asp:Label>.
                                                The parking fee for this space (if applicable is $&nbsp;<asp:Label ID="Parkingfee" runat="server"
                                                    Text="0" ForeColor="Red" />
                                                &nbsp;monthly. Said space shall not be used for the washing, painting, or repair of vehicles.
                                                No other parking space shall be used by RESIDENT or RESIDENT'S guest(s). RESIDENT
                                                is responsible for oil leaks and other vehicle discharges for which RESIDENT shall
                                                be charged for cleaning if deemed necessary by OWNER.</p>
                                            <br />
                                            <p>
                                                11. <b>NOISE:</b> RESIDENT agrees not to cause or allow any noise or activity on
                                                the premises which might disturb the peace and quiet of another RESIDENT and/or
                                                neighbor. Said noise and/or activity shall be a breach of this agreement.
                                            </p>
                                            <br />
                                            <p>
                                                12. <b>DESTRUCTION OF PREMISES:</b> If the premises become totally or partially
                                                destroyed during the term of this Agreement so that RESIDENT'S use is seriously
                                                impaired, OWNER or RESIDENT may terminate this Agreement immediately upon three
                                                day written notice to the other.</p>
                                            <br />
                                            <p>
                                                13. <b>CONDITION OF PREMISES:</b> RESIDENT acknowledges that he has examined the
                                                premises and that said premises, all furnishings, fixtures, furniture, plumbing,
                                                heating, electrical facilities, all items listed on the attached property condition
                                                checklist, if any, and/or all other items provided by OWNER are all clean, and in
                                                good satisfactory condition except as may be indicated elsewhere in this Agreement.
                                                RESIDENT agrees to keep the premises and all items in good order and good condition
                                                and to immediately pay for costs to repair and/or replace any portion of the above
                                                damaged by RESIDENT, his guests and/or invitees, except as provided by law. At the
                                                termination of this Agreement, all of above items in this provision shall be returned
                                                to OWNER in clean and good condition except for reasonable wear and tear and the
                                                premises shall be free of all personal property and trash not belonging to OWNER.
                                                It is agreed that all dirt, holes, tears, burns, and stains of any size or amount
                                                in the carpets, drapes, walls, fixtures, and/or any other part of the premises,
                                                do not constitute reasonable wear and tear.</p>
                                            <br />
                                            <p>
                                                14. <b>ALTERATIONS:</b> RESIDENT shall not paint, wallpaper, alter or redecorate,
                                                change or install locks, install antenna or other equipment, screws, fastening devices,
                                                large nails, or adhesive materials, place signs, displays, or other exhibits, on
                                                or in any portion of the premises without the written consent of the OWNER except
                                                as may be provided by law.
                                            </p>
                                            <br />
                                            <p>
                                                15: <b>PROPERTY MAINTENANCE:</b> RESIDENT shall deposit all garbage and waste in
                                                a clean and sanitary manner into the proper receptacles and shall cooperate in keeping
                                                the garbage area neat and clean. RESIDENT shall be responsible for disposing of
                                                items of such size and nature as are not normally acceptable by the garbage hauler.
                                                RESIDENT shall be responsible for keeping the kitchen and bathroom drains free of
                                                things that may tend to cause clogging of the drains. RESIDENT shall pay for the
                                                cleaning out of any plumbing fixture that may need to be cleared of stoppage and
                                                for the expense or damage caused by stopping of waste pipes or overflow from bathtubs,
                                                wash basins, or sinks.</p>
                                            <br />
                                            <p>
                                                16. <b>HOUSE RULES:</b> RESIDENT shall comply with all house rules as stated on
                                                separate addendum, but which are deemed part of this rental agreement, and a violation
                                                of any of the house rules is considered a breach of this agreement.</p>
                                            <br />
                                            <p>
                                                17. <b>CHANGE OF TERMS:</b> The terms and conditions of this agreement are subject
                                                to future change by OWNER after the expiration of the agreed lease period upon 30-day
                                                written notice setting forth such change and delivered to RESIDENT. Any changes
                                                are subject to laws in existence at the time of the Notice of Change Of Terms.</p>
                                            <br />
                                            <p>
                                                18. <b>TERMINATION:</b> After expiration of the leasing period, this agreement is
                                                automatically renewed from month to month, but may be terminated by either party
                                                giving to the other a 30-day written notice of intention to terminate. Where laws
                                                require "just cause", such just cause shall be so stated on said notice. The premises
                                                shall be considered vacated only after all areas including storage areas are clear
                                                of all RESIDENT'S belongings, and keys and other property furnished for RESIDENT'S
                                                use are returned to OWNER. Should the RESIDENT hold over beyond the termination
                                                date or fail to vacate all possessions on or before the termination date, RESIDENT
                                                shall be liable for additional rent and damages which may include damages due to
                                                OWNER'S loss of prospective new renters.</p>
                                            <br />
                                            <p>
                                                19. <b>POSSESSION:</b> If OWNER is unable to deliver possession of the residence
                                                to RESIDENTS on the agreed date, because of the loss or destruction of the residence
                                                or because of the failure of the prior residents to vacate or for any other reason,
                                                the RESIDENT and/or OWNER may immediately cancel and terminate this agreement upon
                                                written notice to the other party at their last known address, whereupon neither
                                                party shall have liability to the other, and any sums paid under this Agreement
                                                shall be refunded in full. If neither party cancels, this Agreement shall be prorated
                                                and begin on the date of actual possession.</p>
                                            <br />
                                            <p>
                                                20. <b>INSURANCE:</b> RESIDENT acknowledges that OWNERS insurance does not cover
                                                personal property damage caused by fire, theft, rain, war, acts of God, acts of
                                                others, and/or any other causes, nor shall OWNER be held liable for such losses.
                                                RESIDENT is hereby advised to obtain his own insurance policy to cover any personal
                                                losses.
                                            </p>
                                            <br />
                                            <p>
                                                21. <b>RIGHT OF ENTRY AND INSPECTION:</b> OWNER may enter, inspect, and/or repair
                                                the premises at any time in case of emergency or suspected abandonment. OWNER shall
                                                give 24 hours advance notice and may enter for the purpose of showing the premises
                                                during normal business hours to prospective renters, buyers, lenders, for smoke
                                                alarm inspections, and/or for normal inspections and repairs. OWNER is permitted
                                                to make all alterations, repairs and maintenance that in OWNER'S judgment is necessary
                                                to perform.
                                            </p>
                                            <br />
                                            <p>
                                                22. <b>ASSIGNMENT:</b> RESIDENT agrees not to transfer, assign or sublet the premises
                                                or any part thereof.</p>
                                            <br />
                                            <p>
                                                23. <b>PARTIAL INVALIDITY:</b> Nothing contained in this Agreement shall be construed
                                                as waiving any of the OWNER'S or RESIDENT'S rights under the law. If any part of
                                                this Agreement shall be in conflict with the law, that part shall be void to the
                                                extent that it is in conflict, but shall not invalidate this Agreement nor shall
                                                it affect the validity or enforceability of any other provision of this Agreement.</p>
                                            <br />
                                            <p>
                                                24. <b>NO WAIVER:</b> OWNER'S acceptance of rent with knowledge of any default by
                                                RESIDENT or waiver by OWNER of any breach of any term of this Agreement shall not
                                                constitute a waiver of subsequent breaches. Failure to require compliance or to
                                                exercise any right shall not be constituted as a waiver by OWNER of said term, condition,
                                                and/or right, and shall not affect the validity or enforceability of any provision
                                                of this Agreement.</p>
                                            <br />
                                            <p>
                                                25. <b>ATTORNEY FEES:</b> If any legal action or proceedings be brought by either
                                                party of this Agreement, the prevailing party shall be reimbursed for all reasonable
                                                attorney's fees and costs in addition to other damages awarded.
                                            </p>
                                            <br />
                                            <p>
                                                26. <b>JOINTLY AND SEVERALLY:</b> The undersigned RESIDENTS are jointly and severally
                                                responsible and liable for all obligations under this agreement.
                                            </p>
                                            <br />
                                            <p>
                                                27. <b>REPORT TO CREDIT/TENANT AGENCIES:</b> You are hereby notified that a nonpayment,
                                                late payment or breach of any of the terms of this rental agreement may be submitted/reported
                                                to a credit and/or tenant reporting agency, and may create a negative credit record
                                                on your credit report.</p>
                                            <br />
                                            <p>
                                                28. <b>LEAD NOTIFICATION REQUIREMENT:</b> For rental dwellings built before 1978,
                                                RESIDENT acknowledges receipt of the following: Lead Based Paint Disclosure Form
                                                and/or
                                                <br>
                                                EPA Pamphlet</p>
                                            <br />
                                            29. <b>NOTICES:</b> All notices to RESIDENT shall be served at RESIDENT'S premises
                                            and all notices to OWNER shall be served at
                                            <asp:Label ID="OwnerEntireAddress" runat="server" Text=" _______________________________________________________________"
                                                ForeColor="Red"></asp:Label>.</p>
                                    <br />
                                    <p>
                                        30. <b>KEYS AND ADDDENDUMS:</b> RESIDENT acknowledges receipt of the following which
                                        shall be deemed part of this Agreement:(Please Complete)<br>
                                        <asp:Label ID="NumberofKeys" runat="server" Text="_____" ForeColor="Red" CssClass="style1"></asp:Label>
                                        <span class="style1">&nbsp;Keys.</span><br class="style1" />
                                    </p>
                                    <br />
                                    <p>
                                        31. <b>ENTIRE AGREEMENT:</b> This Agreement constitutes the entire Agreement between
                                        OWNER and RESIDENT. No oral agreements have been entered into, and all modifications
                                        or notices shall be in writing to be valid.</p>
                                    <br />
                                    <p>
                                        32. <b>RECEIPT OF AGREEMENT:</b> The undersigned RESIDENTS have read and understand
                                        this Agreement and hereby acknowledge receipt of a copy of this Rental Agreement.</p>
                                    <p>
                                        <br />
                                        <br />
                                        <p>
                                            RESIDENT&#39;S ID or DL ___________________________________________________
                                        </p>
                                        <br />
                                        <p>
                                            RESIDENT'S Signature ___________________________________________________
                                        </p>
                                        <br />
                                        <p>
                                            Date__________________</p>
                                        <p>
                                            <br />
                                            <br />
                                            <p>
                                                <p>
                                                    OWNER'S ID or DL ___________________________________________________
                                                </p>
                                                <br />
                                                <p>
                                                    OWNER'S Signature ___________________________________________________
                                                </p>
                                                <br />
                                                <p>
                                                    Date__________________</p>
                                                <br />
                                </td>
                            </tr>
                        </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
