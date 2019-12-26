using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Caching;
using System.Threading;
public partial class DetailswithTransaction : System.Web.UI.Page
{
    string carddetails = "", payamount = "", txno ="",ttype="";
    string status = "Failed";
    protected void Page_Init(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             GenerateDetails();
        }
        
        
       
    }

    private void GenerateDetails()
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
            carddetails = arrIndMsg[1].ToString().Trim();
            arrIndMsg = arrMsgs[1].Split('='); //Get the Amount
            payamount = arrIndMsg[1].ToString().Trim();
            arrIndMsg = arrMsgs[2].Split('='); //Get the Amount
            txno = (arrIndMsg[1].ToString().Trim());

            arrIndMsg = arrMsgs[3].Split('='); //Get the Amount
            ttype = (arrIndMsg[1].ToString().Trim());
            carddetails = "XXXXX" + carddetails.Substring(12);

            lblCard.Text = carddetails;
            lblAmount.Text = payamount;
            lblTransactioID.Text = txno;
            cardtyp.Text = Convert.ToString(Session["CardTyp"]);
            ViewState["TransactionTime"] = 5;
            Timer1.Enabled = true;

            if (txno != null)
            {
                status = "Success";
                ViewState["PaymentStatus"] = status;
                ViewState["txnNo"] = txno;
                ViewState["TxnAmount"] = payamount;
                ViewState["transactionType"] = ttype;
            }
            lblStatus.Text = status;
        }
        else
        {
            Response.Redirect(Userdata.ClientPageURL);
        }
    }
    private string DecryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(ViewState["TransactionTime"]);
        if (i == 0)
        {
            string txno = ViewState["txnNo"] as string;
            string status = ViewState["PaymentStatus"] as string;
            string transctionAmount = ViewState["TxnAmount"] as string;
            string type = ViewState["transactionType"] as string;
            if (!type.Equals("AddtoWallet"))
            Response.Redirect(Userdata.ClientPageURL + "?transId=" + txno + "&status=" + status);
            else
                Response.Redirect(Userdata.WalletPageURL + "?transId=" + txno + "&status=" + status + "&amount=" + transctionAmount);
        }
        else
        {
            i--;
            ViewState["TransactionTime"] = i;
           
        }
    }
}