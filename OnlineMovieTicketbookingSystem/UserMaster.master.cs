using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserEmail"] == null)
        //    Response.Redirect("Login.aspx");
        //if(Session["UserEmail"] != null)
        //{
        //    string email = Convert.ToString(Session["UserEmail"]);
        //    var user = ConnectionClass.CheckExistingemail(email);
        //    foreach (var item in user)
        //    {
        //        lbluser.Text = item.Name;

        //    }
        //}
    }
    protected void logout_Click(object sender, EventArgs e)
    {
        Session["UserEmail"] = null;
        Session.Abandon();
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
}
