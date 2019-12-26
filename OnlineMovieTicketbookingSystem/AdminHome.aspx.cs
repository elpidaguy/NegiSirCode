using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserEmail"] != null)
        {
            string email = Convert.ToString(Session["UserEmail"]);
            var user = ConnectionClass.CheckExistingemail(email);
            foreach (var item in user)
            {
                lblUser.Text = item.Name;
            }
        }
    }
}