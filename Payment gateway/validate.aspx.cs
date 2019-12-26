using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class validate : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strReq = "";
            strReq = Request.RawUrl;
            strReq = strReq.Substring(strReq.IndexOf('?') + 1);

            if (!strReq.Equals(""))
            {
                strReq = DecryptQueryString(strReq);

                //Parse the value... this is done is very raw format.. you can add loops or so to get the values out of the query string...
                string[] arrMsgs = strReq.Split('&');
                string[] arrIndMsg;
                arrIndMsg = arrMsgs[0].Split('='); //Get the Cardno
                string amt = arrIndMsg[1].ToString().Trim();
                arrIndMsg = arrMsgs[1].Split('='); //Get the Amount
                string transactiontyp = arrIndMsg[1].ToString().Trim();
                //Response.Redirect("transaction.aspx?payamt=" + amt + "&transactionType=" + transactiontyp);
                if (amt != null)// && transactiontyp!=null)
                {
                    string strURL = "transaction.aspx?";
                    string strURLWithData = strURL + EncryptQueryString(string.Format("payamt={0}&transactionType={1}", amt, transactiontyp));
                    Response.Redirect(strURLWithData);
                }
            }
        }
        catch (Exception ex)
        {
            
            
        }
       
    }
    private string DecryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
    }
    public string EncryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
    }
}