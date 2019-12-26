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
       if(!IsPostBack)
       {
           drpUserTyp.Items.Add("Admin");
           drpUserTyp.Items.Add("User");
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
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        string UserEmail = email.Value;
        string UserPassword = EncryptString(password.Value);
        string username = drpDwn.Value + " " + Name.Value;
        string userphone = mobile.Value;
        string title = drpDwn.Value;
        string userTyp = drpUserTyp.SelectedItem.Text;
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
                   
                }
                else
                {
                    bool AddUser = ConnectionClass.AddUser(UserEmail, UserPassword, "Active", userTyp, username, userphone);
                    if (AddUser)
                    {
                         lblregitrationmesg.Text ="User Created SuccessFully";
                        SendMail(UserEmail, "Welcom To Book My Movie", "<b>Welcome to book My Movie!!! <br><div><p><p><font face='Tahoma' size='2'>Thank you for your Registration With Us. <br></p>Dear Customer " + username + ",<br><p>In case you have not logged in to your Account, please call our Customer Care. NEVER SHARE your pasword with anyone.</p><p>Sincerely, Book My Movie Team</p></div></b>");
                       
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