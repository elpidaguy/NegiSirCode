using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
       if(!IsPostBack)
       {
           drpMovieTyp.Items.Add("Action");
           drpMovieTyp.Items.Add("Drama");
           drpMovieTyp.Items.Add("Comedy");
           drpMovieTyp.Items.Add("Thriller");
       }

    }


    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
       
            if(!string.IsNullOrEmpty(MovieName.Value) && !string.IsNullOrEmpty(Description.Value) && !string.IsNullOrEmpty(Director.Value) && !string.IsNullOrEmpty(Convert.ToString(Release_Date.Value))&&  MovieImg.HasFiles && Movie_trailer.HasFiles)
            {

                string fileName = Path.GetFileName(MovieImg.PostedFile.FileName);
                string serverpath = "~/images/movie/";
                string folderpath = "images/movie/";
                string MovieImgPath = Server.MapPath(serverpath) + fileName;
                MovieImg.PostedFile.SaveAs(MovieImgPath);
                string MovieTrailerName = Path.GetFileName(Movie_trailer.PostedFile.FileName);
                string SavingPath = Server.MapPath(serverpath) + MovieTrailerName;
                Movie_trailer.PostedFile.SaveAs(SavingPath);
                string movieType = drpMovieTyp.SelectedItem.Text;
               
                bool SaveMovie = ConnectionClass.InsertMovie(MovieName.Value, Description.Value, Director.Value, Convert.ToString(Release_Date.Value), folderpath + fileName, folderpath + MovieTrailerName, movieType,Cast.Value,Story.Value);
                if(SaveMovie)
                {
                    lblmessage.Text="Movie Added";
                    lblmessage.ForeColor = System.Drawing.Color.Green;
                    MovieName.Value = "";
                    Description.Value = "";
                    Director.Value = "";
                    Release_Date.Value = ("00-00-0000");
                }
                else
                {
                    lblmessage.Text = "Movie Not Added";
                    lblmessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblmessage.Text="Please Fill All Data";
                lblmessage.ForeColor = System.Drawing.Color.Red;
            }

    }

    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        MovieName.Value = "";
        Description.Value = "";
        Director.Value = "";
        Release_Date.Value =("00-00-0000");

    }
}