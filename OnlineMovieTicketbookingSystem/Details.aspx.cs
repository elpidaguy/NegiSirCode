using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MovieDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
                string MovieId = Request.QueryString["MovieID"];
                var MovieData = ConnectionClass.getMovies().Single(movie => movie.MovieID ==Convert.ToInt32( MovieId));
                lblmovie.Text = MovieData.MovieName + " || " + MovieData.Cast;
                lblRelease.Text = MovieData.Release_Date;
                movieTrailer.Src = MovieData.MovieTrailer;
                lblMovieName.Text = MovieData.MovieName;
                lblDirector.Text = MovieData.Director;
                lblReleaseDate.Text = MovieData.Release_Date;
                lblStory.Text = MovieData.Story;
                lblCastData.Text = MovieData.Cast;
                Director.Text = MovieData.Director;
                lblLike.Text = MovieData.Likes.ToString();
                try
                {
                    Rating rtng = ConnectionClass.GetMovieRating((MovieId)).Where(rt => rt.MovieId == Convert.ToInt32(MovieId)).First();
                    int count = ConnectionClass.UserCount(MovieId);
                    lblRating.Text =Convert.ToString(Convert.ToInt32(rtng.MovieId) / count);
                }
                catch (Exception)
                {

                    lblRating.Text = "0";
                }
                
        }

    }
    protected void SubmitRating_Click(object sender, EventArgs e)
    {
        string userEmail = Convert.ToString(Session["UserEmail"]);
        string rating = drpDownRating.Value;
        string MovieId = Request.QueryString["MovieID"];
        if(!string.IsNullOrEmpty(userEmail) && !string.IsNullOrEmpty(rating))
        {
            bool isUserRatedPreviously = ConnectionClass.IsUserRated(userEmail, MovieId);
            if (!isUserRatedPreviously)
            {
                ConnectionClass.RateMovie(userEmail, rating, MovieId);
                bool isRated = ConnectionClass.GetMovieRating((MovieId)).Any();
                if(!isRated)
                {
                    ConnectionClass.AddRating(rating, MovieId);
                }
                else
                {
                    ConnectionClass.UpdateRating(Convert.ToInt32(MovieId), rating);
                }
            }
            else
                lblmesg.Text = "You Already Rate This Movie";
        }

    }
}