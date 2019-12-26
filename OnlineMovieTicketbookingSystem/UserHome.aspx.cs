using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserEmail"] != null)
        {
            if (!IsPostBack)
            {
               // DrawCrousel();
                SelectMovie.Items.Add("--Select Movie--");
                SelectShowTime.Items.Add("--Select Time--");
               getMoviesName();
               getMovies();
             //  FlexiSlider();
               SelectTheatre.Items.Add("--Select Theatre--");
                getDate();
                for (int i = 1; i < 10; i++)
                    SelectSeats.Items.Add(i.ToString());
            }
        }
        else
            Response.Redirect("Login.aspx");

    }

    public void getMoviesName()
    {

        var MovieData = ConnectionClass.ActiveMovies();
        var MovieItemCollection = ConnectionClass.getMovies();
      //  string list = "<ul class='slides'>";
        foreach (var Mvitem in MovieData)
        {
            foreach (var item in MovieItemCollection)
            {
                if (item.MovieID == Mvitem.CureentMovie)
                {
                    ListItem newItem = new ListItem(item.MovieName.Trim(), Convert.ToString(item.MovieID));
                    if(!SelectMovie.Items.Contains(newItem))
                    SelectMovie.Items.Add(newItem);
                }
            }
            
        }
       

    }

    public void getTheatre()
    {

        var TheatreData = ConnectionClass.getTheatre();
        SelectTheatre.Items.Add("--Select Theatre--");
        foreach (var item in TheatreData)
        {
            ListItem newItem = new ListItem(item.ThatreName.Trim(), Convert.ToString(item.ThatreID));
            
            SelectTheatre.Items.Add(newItem);
        }

    }

    public void getTheatreData()
    {
        SelectTheatre.Items.Add("--Select Theatre--");
        var TheatreData = ConnectionClass.ActiveMovies();
        var theatreCollection = ConnectionClass.getTheatre();
        foreach (var theatreitem in TheatreData)
        {
            foreach (var item in theatreCollection)
            {
                if ((theatreitem.CurrentTheatre == item.ThatreID) && (theatreitem.CureentMovie==Convert.ToInt32(SelectMovie.SelectedValue)))
                {
                    ListItem newItem = new ListItem(item.ThatreName.Trim(), Convert.ToString(item.ThatreID));
                    if(!SelectTheatre.Items.Contains(newItem))
                    SelectTheatre.Items.Add(newItem);
                    var ShowTimeCollection = ConnectionClass.getShowCollection(Convert.ToInt32(SelectMovie.SelectedValue), item.ThatreID);
                    SelectShowTime.Items.Clear();
                    SelectShowTime.Items.Add("--Select Time--");
                    foreach (Show_Tbl showtime in ShowTimeCollection)
                    {
                        ListItem timeData = new ListItem(showtime.ShowTime.Trim(), Convert.ToString(showtime.ShowID));
                        if (!SelectShowTime.Items.Contains(timeData))
                        {
                            SelectShowTime.Items.Add(timeData);
                        }
                    }
                    foreach (Show_Tbl showtime in ShowTimeCollection)
                    {
                        SelectSeats.Items.Clear();
                        SelectSeats.Items.Add("--Select Seats--");
                        for (int i = 1; i <= showtime.RemainingSeats;i++ )
                        {
                            SelectSeats.Items.Add(i.ToString());
                        }
                    }

                }
            }

        }
    }
    public void getDate()
    {
        DateTime dt = System.DateTime.Now;
        SelectDate.Items.Add(dt.ToShortDateString());
        SelectDate.Items.Add(dt.AddDays(1).ToShortDateString());
        SelectDate.Items.Add(dt.AddDays(2).ToShortDateString());
    }
    public void getMovies()
    {
        string list = "<ul class='slides'>";
        var MovieData = ConnectionClass.getMovies();
        //string flexi = String.Empty;
        foreach (var item in MovieData)
        {
            if (item.MovieImage != null)
            {
                list += "<li><img src='" + item.MovieImage + "' class='img-responsive' alt='' /></li>";
                //flexi+="<li><a href='movies.html'><img src='" + item.MovieImage + "' alt='' height=270 width=220/></a>";
                //flexi+="<div class='slide-title'><h4>" + item.MovieName + "</h4> </div>";
                //flexi+="<div class='date-city'><h5>" + item.Release_Date + "</h5>";
                //flexi+="<div class='buy-tickets'><a href='movie-select-show.aspx?MovieID=" + item.MovieID + ">BUY TICKETS</a></div></div></li>";
            }
        }
        list += "</ul>";
        SliderDiv.InnerHtml = list;
        //flexiselDemo1.InnerHtml = flexi +"</ul>";
    }
  
    protected void book_ticket_Click(object sender, EventArgs e)
    {
        string Moviename = SelectMovie.SelectedItem.Text;
        string MovieID = SelectMovie.SelectedItem.Value;
        string theatrename = SelectTheatre.SelectedItem.Text;
        string theatreID = SelectTheatre.SelectedItem.Value;
        string selectedDate = SelectDate.SelectedItem.Text + " Show Time :"+ SelectShowTime.SelectedItem.Text;
        string seats=SelectSeats.SelectedItem.Text;
        DataTable dt = new DataTable();
        dt.Columns.Add("Moviename");
        dt.Columns.Add("MovieID");
        dt.Columns.Add("TheatreName");
        dt.Columns.Add("TheaterID");
        dt.Columns.Add("SelectedDate");
        dt.Columns.Add("selectTotalSeats");
        dt.Columns.Add("BookedSeats");
        dt.Columns.Add("UserEmail");
        dt.Columns.Add("ShowID");
        DataRow dr = dt.NewRow();
        dr["Moviename"] = Moviename;
        dr["MovieID"] = MovieID;
        dr["TheatreName"] = theatrename;
        dr["TheaterID"] = theatreID;
        dr["SelectedDate"] = selectedDate;
        dr["selectTotalSeats"] = seats;

        string selectseatcount = SelectSeats.SelectedItem.Text;
       
        string movietime = SelectShowTime.SelectedItem.Text;
        List<string> seatlist = new List<string>();

        int getShowIdforCurrentMovie = 0;
        var seatsCountIntheatre = ConnectionClass.getShowSeats(Convert.ToInt32(MovieID),Convert.ToInt32( theatreID), movietime);
        int seatcount = 0;
        foreach (var item in seatsCountIntheatre)
        {
            seatcount = Convert.ToInt32(item.RemainingSeats);
            getShowIdforCurrentMovie = item.ShowID;
        }

        int getBookingID = ConnectionClass.getBookingCollection(getShowIdforCurrentMovie);
        int[] d = ConnectionClass.getSeatsCollection(Convert.ToString(getBookingID)).ToArray();

        string s = "";
        int count = 0;
        foreach (int x in d)
        {
            if (count == 0)
                s = s + x;
            else
                s = s + "," + x;
            count++;
        }
        dr["BookedSeats"] = s;
        dr["UserEmail"] =Convert.ToString( Session["UserEmail"]);
        dr["ShowID"] = getShowIdforCurrentMovie;
        dt.Rows.Add(dr);
        Session["Booked_Data"] = dt;
        Response.Redirect("SelectSeats.aspx?data=" + s + "&selectSeatCount=" + selectseatcount + "&seatcountIntheatre=" + seatcount);
       // Response.Redirect("UserConfirmBooking.aspx?Moviename=" + Moviename + "&TheatreName=" + theatrename + "&MovieID=" + MovieID + "&theatreID=" + theatreID + "&selectedDate=" + selectedDate + "&selectTotalSeats=" + seats);
    
    }
    private void getBookedData()
    {
        string selectseatcount = SelectSeats.SelectedItem.Text;
        int theatreID = Convert.ToInt32(SelectTheatre.SelectedItem.Value);
        int MovieID = Convert.ToInt32(SelectMovie.SelectedItem.Value);
        string movietime = SelectShowTime.SelectedItem.Text;
        List<string> seatlist = new List<string>();

        int getShowIdforCurrentMovie = ConnectionClass.getShow(MovieID, theatreID, movietime);
        var seatsCountIntheatre = ConnectionClass.getShowSeats(MovieID, theatreID, movietime);
        int seatcount = 0;
        foreach (var item in seatsCountIntheatre)
        {
            seatcount = Convert.ToInt32(item.RemainingSeats);
        }

        int getBookingID = ConnectionClass.getBookingCollection(getShowIdforCurrentMovie);
        int[] d = ConnectionClass.getSeatsCollection(Convert.ToString(getBookingID)).ToArray();

        string s = string.Empty;
        int count = 0;
        foreach (int x in d)
        {
            if (count == 0)
                s = s + x;
            else
                s = s + "," + x;
            count++;
        }
                Response.Redirect("SelectSeats.aspx?data=" + s + "&selectSeatCount=" + selectseatcount+"&seatcountIntheatre="+seatcount);
           

       
    }
    protected void SelectMovie_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectTheatre.Items.Clear();
        getTheatreData();
    }

   public void FlexiSlider()
    {
        StringBuilder builder = new StringBuilder();
        var MovieData = ConnectionClass.getMovies();
       
        foreach (var item in MovieData)
        {
            if (item.MovieImage != null)
            {
               builder.Append("<li><a href='movies.html'><img src='"+item.MovieImage+"' alt='' height=270 width=220/></a>"); 	
		       builder.Append("<div class='slide-title'><h4>"+item.MovieName+"</h4> </div>");
			    builder.Append("<div class='date-city'><h5>"+item.Release_Date+"</h5>");
                builder.Append("<div class='buy-tickets'><a href='movie-select-show.aspx?MovieID="+item.MovieID+">BUY TICKETS</a></div></div></li>");
				
            }
        }
        	
      // flexiselDemo1.InnerHtml = builder.ToString();
    }
}