using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forgotpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_forgotpassword_Click(object sender, EventArgs e)
    {
        try
        {
            string Email = Convert.ToString(Session["UserEmail"]);
            string Pswd = Password.Text.Trim();
            string cpassword = ConfrmPassword.Text.Trim();

            if (!string.IsNullOrEmpty(Pswd) && !string.IsNullOrEmpty(cpassword))
            {
                var Info = ConnectionClass.CheckExistingemail(Email);
                foreach (var item in Info)
                {
                    ConnectionClass.UpdatePassword(Email,EncryptString(Pswd));
                    SendMail(Email, "Your Password", "Your Password Is Changed Successfully For Login in Techno Theatre Ticket Booking System is - " + DecryptQueryString(Pswd));
                    lbl_message.Text = "Password Sent to your Register Email ID";
                    lbl_message.ForeColor = System.Drawing.Color.Green;
                    lbl_message.Visible = true;
                    
                    break;

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
                lbl_message.Text =ex.Message;
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
}