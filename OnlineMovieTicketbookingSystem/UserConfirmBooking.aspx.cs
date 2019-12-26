using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConfirmBooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string offerdata = Request.QueryString["fromOffer"];
        if (offerdata.Equals("yes"))
            BookOfferDataConfirm();
        else
            ConfirmBookingData();

    }

    private void BookOfferDataConfirm()
    {
        string ShowID =Request.QueryString["ShowID"];
        DataTable dt = ConnectionClass.GetOfferedData();
        foreach (DataRow item in dt.Rows)
        {
            if (Convert.ToString(item["ShowID"]).Equals(ShowID))
            {
                Date_lbl.Text = Convert.ToString(item["MovieDate"]);
                MovieLbl.Text = Convert.ToString(item["MovieName"]);
                TheatrLbl.Text = Convert.ToString(item["TheatreName"]);
                lblSeats.Text = Convert.ToString(item["SeatNo"]);
                int selectseatcount = lblSeats.Text.Split(',').Count();
                int amt = selectseatcount * 200;
                lblAmt.Text = amt.ToString();
                lblServiceTax.Text = (amt * .14).ToString();
                double totlaAmt = amt + (amt * .14);
                var wallet = ConnectionClass.getWalletAmount(Convert.ToString(Session["UserEmail"]));
                foreach (var walet in wallet)
                {
                    totlaAmt = Convert.ToDouble(totlaAmt) - Convert.ToDouble(walet.Amount);
                    Session["walletAmountUsed"] = walet.Amount;
                }
                lblTotal.Text = (totlaAmt).ToString();
                break;
            }

        }
    }

    private void ConfirmBookingData()
    {
        if (Session["Booked_Data"] != null)
        {



            string BookedSeats = Request.QueryString["BookedSeatNo"];
            Session["BookedSeats"] = BookedSeats;
            DataTable dt = Session["Booked_Data"] as DataTable;
            foreach (DataRow item in dt.Rows)
            {
                Date_lbl.Text = Convert.ToString(item["SelectedDate"]);
                MovieLbl.Text = Convert.ToString(item["Moviename"]);
                TheatrLbl.Text = Convert.ToString(item["TheatreName"]);
                lblSeats.Text = BookedSeats;
                int selectseatcount = Convert.ToInt32(item["selectTotalSeats"]);
                int amt = selectseatcount * 200;
                lblAmt.Text = amt.ToString();
                lblServiceTax.Text = (amt * .14).ToString();
                double totlaAmt = amt + (amt * .14);
                var wallet = ConnectionClass.getWalletAmount(Convert.ToString(Session["UserEmail"]));
                foreach (var walet in wallet)
                {
                    totlaAmt = Convert.ToDouble(totlaAmt) - Convert.ToDouble(walet.Amount);
                    Session["walletAmountUsed"] = walet.Amount;
                }
                lblTotal.Text = (totlaAmt).ToString();
                break;
            }
        }
    }
    private string DecryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
    }
    public string EncryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
    }
    protected void Continue_Click(object sender, EventArgs e)
    {
        Session["Amount"] = lblTotal.Text;
        if (Convert.ToInt32(lblTotal.Text) > 0)
        {
            string strURL = Constant.WalletURL;

            string strURLWithData = strURL + EncryptQueryString(string.Format("payamt={0}&transactionType=PayAmount", lblTotal.Text));
            Response.Redirect(strURLWithData);
            Response.Redirect(Constant.PaymentURL + lblTotal.Text);

        }
        else
        {
            System.Random trnno = new System.Random((int)System.DateTime.Now.Ticks);
            int txno = trnno.Next(1, 999999999);
            Response.Redirect("GenerateTicket.aspx?transId=" + txno + "&status=success");
        }
    }

    //private void getBookedData()
    //{
    //    string selectseatcount = Request.QueryString["selectTotalSeats"];
    //    int theatreID = Convert.ToInt32(Request.QueryString["theatreID"]);
    //    int MovieID = Convert.ToInt32(Request.QueryString["MovieID"]);

    //    List<string> seatlist = new List<string>();

    //    int getShowIdforCurrentMovie = ConnectionClass.getShow(MovieID, theatreID);
    //    Session["ShowID"] = getShowIdforCurrentMovie;
    //    if (getShowIdforCurrentMovie > 0)
    //    {
    //        int getBookingID = ConnectionClass.getBookingCollection(getShowIdforCurrentMovie);
    //        if (getBookingID > 0)
    //        {
    //            int[] d = ConnectionClass.getSeatsCollection(Convert.ToString(getBookingID)).ToArray();
              
    //            string s = "";
    //            int count = 0;
    //            foreach (int x in d)
    //            {
    //                if (count == 0)
    //                    s = s + x;
    //                else
    //                    s = s + "," + x;
    //                count++;
    //            }
    //            Response.Redirect("SelectSeats.aspx?data=" + s + "&selectSeatCount=" + selectseatcount);
    //        }

    //    }
    //}


    protected void Cancel_Click(object sender, EventArgs e)
    {
        Session["Booked_Data"] = null;
        Session.Clear();
        Response.Redirect("UserHome.aspx");
    }
}
