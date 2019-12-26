using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmessage.Visible = false;
        lblregitrationmesg.Visible = false;
    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        string EmailID = email1.Value;
        string Password = exampleInputPassword1.Value;
        if(!string.IsNullOrEmpty(EmailID) && !string.IsNullOrEmpty(Password))
        {
            var lgn = ConnectionClass.LoginUser(EmailID,EncryptString(Password));
            if(lgn.Any())
            {
                foreach (var item in lgn)
                {
                    Session["UserEmail"] = email1.Value;
                    Session["UserType"] = item.UserType;
                    if(item.UserType.Equals("Admin"))
                    Response.Redirect("AdminHome.aspx");
                    else
                        Response.Redirect("UserHome.aspx");
                }
               
            }
            else
            {
                lblmessage.Text = "Wrong Credentials";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Visible = true;
            }
        }
    }
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        string UserEmail = email.Value;
        string UserPassword = EncryptString(password.Value);
        string username = drpDwn.Value + " " + Name.Value;
        string userphone = mobile.Value; 
        try
        {
            if (!string.IsNullOrEmpty(UserEmail) && !string.IsNullOrEmpty(UserEmail) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(userphone))
            {
                bool lgn = ConnectionClass.CheckExistingemail(UserEmail).Any();
                if (lgn)
                {
                    lblregitrationmesg.Text = "Email Already Exists";
                    lblregitrationmesg.ForeColor = System.Drawing.Color.Red;
                    lblregitrationmesg.Visible = true;
                    lblmessage.Text = "Email Already Exists";
                    lblmessage.ForeColor = System.Drawing.Color.Red;
                    lblmessage.Visible = true;
                }
                else
                {
                    bool AddUser = ConnectionClass.AddUser(UserEmail, UserPassword, "Active", "User", username, userphone);
                    if (AddUser)
                    {
                        Response.Write("<script>User Created SuccessFully</script>");
                        SendMail(UserEmail, "Welcom To Book My Movie", "Welcome to Techno Theatre!!! Thank you for your Registration With Us. Dear Customer " + username + ",In case you have not logged in to your Account, please call our Customer Care. NEVER SHARE your pasword with anyone. Sincerely, Techno Theatre Team");
                        Session["UserEmail"] = UserEmail;
                        Response.Redirect("UserHome.aspx");
                    }
                    else
                    {
                        lblregitrationmesg.Text = "Server Error";
                        lblregitrationmesg.ForeColor = System.Drawing.Color.Red;
                        lblregitrationmesg.Visible = true;
                    }
                }
            }
            else
            {
                lblregitrationmesg.Text = "Please Fill All Details Properly";
                lblregitrationmesg.ForeColor = System.Drawing.Color.Red;
                lblregitrationmesg.Visible = true;
            }
        }
        catch (Exception ex)
        {

            lblregitrationmesg.Text = "Something gonna wrong we will in touch soon";
            lblregitrationmesg.ForeColor = System.Drawing.Color.Red;
            lblregitrationmesg.Visible = true;
        }

    }
    private string DecryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Decrypt(strQueryString, Constant.EncryptionKey);
    }
    public string EncryptString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Encrypt(strQueryString, Constant.EncryptionKey);
    }
    public static void SendMail(string ToUser, string Msgsubject, string MsgBody)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(Constant.SMTPClient);
            mail.From = new MailAddress(Constant.EmailUseEmail);
            mail.To.Add(ToUser);
            if (string.IsNullOrEmpty(Msgsubject))
                Msgsubject = Constant.DefaultSubject;
            if (string.IsNullOrEmpty(MsgBody))
                MsgBody = Constant.DefaultBody;
            mail.Subject = Msgsubject;
            mail.Body = MsgBody;
            SmtpServer.Port = Constant.ServerPort;
            SmtpServer.Credentials = new System.Net.NetworkCredential(Constant.EmailUseEmail, Constant.EmailUserPassword);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);

        }
        catch (Exception ex)
        {

        }
    }
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        email.Value = string.Empty;
        password.Value = string.Empty;
        mobile.Value = string.Empty;
        Name.Value = string.Empty;
    }
}