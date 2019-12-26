using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NowShowing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            var MovieData = ConnectionClass.getMovies();
            StringBuilder builder = new StringBuilder();
            foreach (Movie_Tbl item in MovieData)
            {
                if(Convert.ToDateTime(item.Release_Date) > System.DateTime.Now )
                {
                    builder.Append("<div class='col-md-3 cinema-chain-grid text-center'>");
                    builder.Append("<a href='Details.aspx?MovieID="+item.MovieID+"'><img src='"+item.MovieImage+"' alt='' /></a>");
                    builder.Append("<a href='Details.aspx?MovieID=" + item.MovieTyp + "'>" + item.MovieTyp + "</a>");
                    builder.Append("<p>("+ item.MovieName+") <br/> Release Date : "+item.Release_Date+"</p></div>");	
                }
            }
            CurrentMovie.InnerHtml = builder.ToString();
        }
    }
}