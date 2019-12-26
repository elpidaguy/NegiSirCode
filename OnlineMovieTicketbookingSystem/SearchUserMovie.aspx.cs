using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchMovie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            getAllMovies();
        }
    }

    private void getAllMovies()
    {
        var allmovies = ConnectionClass.getMovies();
        DataTable dt = new DataTable();
        dt.Columns.Add("MovieName");
        dt.Columns.Add("Description");
        dt.Columns.Add("Director");
        dt.Columns.Add("Release_Date");
        foreach (var item in allmovies)
        {
            DataRow dr = dt.NewRow();
            dr["MovieName"] = item.MovieName;// Convert.ToString("<a href='Details.aspx?MovieID='" + item.MovieID + "'" + item.MovieName + "</a>");
            dr["Description"] = item.Description;
            dr["Director"] = item.Director;
            dr["Release_Date"] = item.Release_Date;
            dt.Rows.Add(dr);
        }
        MovieGrid.DataSource = dt;
        MovieGrid.DataBind();
    }
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        if(!string.IsNullOrEmpty(MovieName.Value))
        {
            var data = ConnectionClass.getMovie(MovieName.Value).Where(movie => movie.MovieName.Contains(MovieName.Value));
            DataTable dt = new DataTable();
            dt.Columns.Add("MovieName");
            dt.Columns.Add("Description");
            dt.Columns.Add("Director");
            dt.Columns.Add("Release_Date");
            foreach (var item in data)
            {
                DataRow dr = dt.NewRow();
                dr["MovieName"] = item.MovieName;// Convert.ToString("<a href='Details.aspx?MovieID='" + item.MovieID + "'" + item.MovieName + "</a>");
                dr["Description"] = item.Description;
                dr["Director"] = item.Director;
                dr["Release_Date"] = item.Release_Date;
                dt.Rows.Add(dr);
            }
            MovieGrid.DataSource = dt;
            MovieGrid.DataBind();
        }
       
    }
  
    protected void btn_All_Click(object sender, EventArgs e)
    {
        getAllMovies();
    }
}