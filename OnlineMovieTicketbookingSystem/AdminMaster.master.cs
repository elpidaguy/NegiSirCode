using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserEmail"] == null || Session["UserType"] != "Admin")
            Response.Redirect("Login.aspx");
        //if (Session["UserEmail"] == null)
        //{
        //    Response.Redirect("Login.aspx");
        //}
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}
