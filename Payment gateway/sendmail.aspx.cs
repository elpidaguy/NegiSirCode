﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Net;
using System.Net.Mail;

public partial class sendmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SendEmail(object sender, EventArgs e)
    {
        try
        {
            using (MailMessage mm = new MailMessage(txtEmail.Text, txtTo.Text))
            {
                mm.Subject = txtSubject.Text;
                mm.Body = txtBody.Text;
                if (fuAttachment.HasFile)
                {
                    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                }
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(txtEmail.Text, txtPassword.Text);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
            }
        }
        catch(Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }
}