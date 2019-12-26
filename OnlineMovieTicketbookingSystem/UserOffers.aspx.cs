using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserOffers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       getUserOffers();

    }

    private void getUserOffers()
    {
      
        var userOfferData = ConnectionClass.GetOfferedData();
        GridView1.DataSource = userOfferData;
        GridView1.DataBind();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button lnkView = new Button();
            lnkView.Text = "Book Ticket";
            lnkView.Click += BtnClick;
            lnkView.CssClass = "btn";
            lnkView.CommandArgument = (e.Row.DataItem as DataRowView).Row["ShowID"].ToString();
            lnkView.CommandName = "Click";
            e.Row.Cells[6].Controls.Add(lnkView);
            
        }
    }

    private void BtnClick(object sender, EventArgs e)
    {
        Button lnkView = (sender as Button);
        GridViewRow row = (lnkView.NamingContainer as GridViewRow);
        string ShowID = lnkView.CommandArgument;
        Response.Redirect("UserConfirmBooking.aspx?ShowID=" + ShowID + "&fromOffer=yes");
    }

    
}