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
            ShowAllTheatre();
        }
    }

    private void ShowAllTheatre()
    {
        var Alltheatres = ConnectionClass.getTheatre();
        DataTable dt = new DataTable();
        dt.Columns.Add("Theatre ID");
        dt.Columns.Add("Theatre Name");
        dt.Columns.Add("Area");

        foreach (var item in Alltheatres)
        {
            DataRow dr = dt.NewRow();
            dr[0] = item.ThatreID;
            dr[1] = item.ThatreName;
            dr[2] = item.Area;

            dt.Rows.Add(dr);
        }
        MovieGrid.DataSource = dt;
        MovieGrid.DataBind();
    }
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        if(!string.IsNullOrEmpty(MovieName.Value))
        {
            var data = ConnectionClass.getTheatre().Where(theatre => theatre.ThatreName.Contains(MovieName.Value));
            DataTable dt = new DataTable();
            dt.Columns.Add("Theatre ID");
            dt.Columns.Add("Theatre Name");
            dt.Columns.Add("Area");
           
            foreach (var item in data)
            {
                DataRow dr = dt.NewRow();
              
                dr[0] = item.ThatreID;
                dr[1] = item.ThatreName;
                dr[2] = item.Area;

                dt.Rows.Add(dr);
            }
            MovieGrid.DataSource = dt;
            MovieGrid.DataBind();
        }
       
    }
  
    protected void btn_All_Click(object sender, EventArgs e)
    {
        ShowAllTheatre();
    }
}