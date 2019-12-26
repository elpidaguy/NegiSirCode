using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            getMoviesName();
            getTheatre();
            getSeats();
            time.Items.Add("AM");
            time.Items.Add("PM");
            
        }

    }

    private void getSeats()
    {
      for(int i=0;i<71;i++)
      {
          Seats.Items.Add(i.ToString());
      }
    }
    public void getMoviesName()
    {

        var MovieData = ConnectionClass.getMovies();
        foreach (var item in MovieData)
        {
            ListItem newItem = new ListItem(item.MovieName.Trim(), Convert.ToString(item.MovieID));
            MvdrpDwn.Items.Add(newItem);
        }

    }

    public void getTheatre()
    {

        var TheatreData = ConnectionClass.getTheatre();
        foreach (var item in TheatreData)
        {
            ListItem newItem = new ListItem(item.ThatreName.Trim(), Convert.ToString(item.ThatreID));
            TheatreName.Items.Add(newItem);
        }

    }

    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(showTime.Value))
            {
                string shwtime = showTime.Value + " " + time.Value;
                bool insertShow = ConnectionClass.InsertShow(Convert.ToInt32(MvdrpDwn.Value), Convert.ToInt32(TheatreName.Value), shwtime, Convert.ToInt32(Seats.Value));
                if (insertShow)
                {
                    lblregitrationmesg.Text = "Show Added Successfully";
                    lblregitrationmesg.ForeColor = System.Drawing.Color.Green;
                    showTime.Value = "";

                }
                else
                {
                    lblregitrationmesg.Text = "Failed";
                    lblregitrationmesg.ForeColor = System.Drawing.Color.Green;
                }
            }

        }
        catch (Exception ex)
        {
            
             lblregitrationmesg.Text = "Error "+ ex.Message;
                lblregitrationmesg.ForeColor = System.Drawing.Color.Green;
        }
       

    }
  
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        showTime.Value = "";
    }
}