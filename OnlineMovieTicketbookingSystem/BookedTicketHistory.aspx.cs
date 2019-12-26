using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookedTicketHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        printTicket.Visible = false;
        
    }
   
    protected void grdCustomPagging_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEW")
        {
            LinkButton lnkView = (LinkButton)e.CommandSource;
            string BookingID = lnkView.CommandArgument;
            printTicket.Visible = true;
            DataTable bookingData = ConnectionClass.GenerateTicket(Convert.ToInt32(BookingID));
            foreach (DataRow item in bookingData.Rows)
            {
                Date_lbl.Text = Convert.ToString(item["MovieDate"]);
                MovieLbl.Text = Convert.ToString(item["MovieName"]);
                TheatrLbl.Text = Convert.ToString(item["TheatreName"]);
                List<int> seatlist = (List<int>)item["SeatNo"];
                string d = string.Empty;
                foreach (var seat in seatlist)
                {
                    d += Convert.ToString(seat) + ",";
                }
                lblSeats.Text = d;
                paymntStatus.Text = Convert.ToString(item["Bookedstatus"]);
                int amount = (seatlist.Count * 200);
                lblAmt.Text = Convert.ToString(amount);
                double service = Convert.ToDouble(amount * .14);
                double totalamt = amount + service;
                lblServiceTax.Text = Convert.ToString(service);
                lblTotal.Text = Convert.ToString(totalamt);


            }
            lblmessg.Text = "Note : This is System Generated Slip";
            lblmessg.ForeColor = System.Drawing.Color.Green;

        }
        if (e.CommandName == "CANCEL")
        {
            printTicket.Visible = false;
            LinkButton lnkView = (LinkButton)e.CommandSource;
            string BookingID = lnkView.CommandArgument;
            bool cancel = ConnectionClass.CancelTicket(Convert.ToInt32(BookingID));
            if (cancel)
            {
                lblmessg.Text = "Ticket Canceled Refunded amount will be Added to Your wallet";
                lblmessg.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblmessg.Text = "Ticket Not Canceled";
                lblmessg.ForeColor = System.Drawing.Color.Green;
            }

        }
    }

}