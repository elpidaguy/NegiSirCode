using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GenerateTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GenerateTicketData();
        }
        catch (Exception ex)
        {
                      
        }
    }

    private void GenerateTicketData()
    {
        if (Session["Booked_Data"] != null)
        {
            lblSeats.Text = Convert.ToString(Session["BookedSeats"]);
            if (!IsPostBack)
            {
                string bookedStatus = Request.QueryString["status"];
                string transactionID = Request.QueryString["transId"];
                paymntStatus.Text = bookedStatus;

                bool checkTransactionID = ConnectionClass.CheckExistingTransaction(transactionID).Any();
                if (!checkTransactionID)
                {
                    DataTable dt = Session["Booked_Data"] as DataTable;
                    foreach (DataRow item in dt.Rows)
                    {
                        Date_lbl.Text = Convert.ToString(item["SelectedDate"]);
                        MovieLbl.Text = Convert.ToString(item["Moviename"]);
                        TheatrLbl.Text = Convert.ToString(item["TheatreName"]);
                        lblSeats.Text = Convert.ToString(item["BookedSeats"]); ;
                        int selectseatcount = Convert.ToInt32(item["selectTotalSeats"]);
                        int amt = selectseatcount * 200;
                        lblAmt.Text = amt.ToString();
                        lblServiceTax.Text = (amt * .14).ToString();
                        lblTotal.Text = (amt + (amt * .14)).ToString();
                        string ShowID = Convert.ToString(item["ShowID"]);
                        string userMail = Convert.ToString(item["UserEmail"]);
                        string currentDate = System.DateTime.Now.ToShortDateString();
                        string ticketDate = Convert.ToString(item["SelectedDate"]);
                        string[] SeatArr = Convert.ToString(Session["BookedSeats"]).Split(',');
                        lblSeats.Text = Convert.ToString(Session["BookedSeats"]);
                        if (!checkTransactionID)
                        {
                            ConnectionClass.BookTicket(ShowID, transactionID, userMail, currentDate, ticketDate, bookedStatus, SeatArr);
                            ConnectionClass.UpdateWallet(userMail, 0);
                            ConnectionClass.InsertTransaction(userMail, lblTotal.Text, bookedStatus, transactionID);
                        }
                        break;
                    }
                }
                else
                {
                    msg.Text = "Transaction can not perform on same transaction ID";
                    msg.ForeColor = System.Drawing.Color.Red;
                }
              
            }
        }

    }

    //private List<int> getBookedData(int MovieID, int theatreID)
    //{
        
    //    List<int> seatlist = new List<int>();

    //    int getShowIdforCurrentMovie = ConnectionClass.getShow(MovieID, theatreID);
    //    if (getShowIdforCurrentMovie > 0)
    //    {
    //        int getBookingID = ConnectionClass.getBookingCollection(getShowIdforCurrentMovie);
    //        if (getBookingID > 0)
    //        {
    //            seatlist = ConnectionClass.getSeatsCollection(Convert.ToString(getBookingID));
    //            return seatlist;
    //        }

    //    }
    //    return seatlist;
    //}
}