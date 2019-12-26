using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Send_Click(object sender, EventArgs e)
    {
        string username = name.Text.Trim();
        string useremail = email.Text.Trim();
        string userphone = phone.Text.Trim();
        string subj = subject.Text.Trim();
        string mesg = comments.Text.Trim();
        try
        {

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(useremail) && !string.IsNullOrEmpty(subj) && !string.IsNullOrEmpty(userphone) && !string.IsNullOrEmpty(mesg))
            {


                if (ConnectionClass.ContactUSValue(username, useremail, userphone, subj, mesg))
                {
                    lbl_message.Text = "Thank You For Request We Will Back in touch Soon";
                    lbl_message.ForeColor = System.Drawing.Color.Green;
                    lbl_message.Visible = true;
                    name.Text = string.Empty;
                    email.Text = string.Empty;
                    phone.Text = string.Empty;
                    subject.Text = string.Empty;
                    comments.Text = string.Empty;
                }
                else
                {
                    lbl_message.ForeColor = System.Drawing.Color.Red;
                    lbl_message.Visible = true;
                    lbl_message.Text = "Server Error";
                }
                
            }
            else
            {
                lbl_message.ForeColor = System.Drawing.Color.Red;
                lbl_message.Visible = true;
                lbl_message.Text = "Please Input all Details";
            }
        }
        catch (Exception ex)
        {

            lbl_message.ForeColor = System.Drawing.Color.Red;
            lbl_message.Visible = true;
            lbl_message.Text = ex.Message;
        }
    }
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        name.Text = string.Empty;
        email.Text = string.Empty;
        phone.Text = string.Empty;
        subject.Text = string.Empty;
        comments.Text = string.Empty;
        lbl_message.Text = string.Empty;
    }
}