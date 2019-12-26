using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }


    protected void Btn_Submit_Click(object sender, EventArgs e)
    {

        try
        {
            if (!string.IsNullOrEmpty(theatreName.Value) && !string.IsNullOrEmpty(Area.Value) && !string.IsNullOrEmpty(Address.Value))
            {
                var isAdded = ConnectionClass.InsertTheatre(theatreName.Value, Area.Value, Address.Value);
                if (isAdded)
                {
                    lblMessage.Text = "Theatre Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    theatreName.Value = "";
                    Area.Value = "";
                    Address.Value = "";
                }


            }
            else
            {
                lblMessage.Text = "Please Fill All Details";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            
             lblMessage.Text = "Error " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
        }
       
    }
   
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        theatreName.Value = "";
        Area.Value = "";
        Address.Value = "";
    }
}