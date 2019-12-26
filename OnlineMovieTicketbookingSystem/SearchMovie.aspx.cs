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
            var allmovies = ConnectionClass.getMovies();
            DataTable dt = new DataTable();
            dt.Columns.Add("MovieName");
            dt.Columns.Add("Description");
            dt.Columns.Add("Director");
            dt.Columns.Add("Release_Date");
            foreach (var item in allmovies)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item.MovieName;
                dr[1] = item.Description;
                dr[2] = item.Director;
                dr[3] = item.Release_Date;
                dt.Rows.Add(dr);
            }
            MovieGrid.DataSource = dt;
            MovieGrid.DataBind();
        }
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
                dr[0] = item.MovieName;
                dr[1] = item.Description;
                dr[2] = item.Director;
                dr[3] = item.Release_Date;
                dt.Rows.Add(dr);
            }
            MovieGrid.DataSource = dt;
            MovieGrid.DataBind();
        }
       
    }
  
    protected void btn_All_Click(object sender, EventArgs e)
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
            dr[0] = item.MovieName;
            dr[1] = item.Description;
            dr[2] = item.Director;
            dr[3] = item.Release_Date;
            dt.Rows.Add(dr);
        }
        MovieGrid.DataSource = dt;
        MovieGrid.DataBind();
    }
}