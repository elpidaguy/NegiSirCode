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

public partial class ConfirmTransaction : System.Web.UI.Page
{
   static string cardno = "", payamount = "",pin= "",cvv="",expdat="",transtype="";
   static long txno = 0;
   protected void Page_Init(object sender, EventArgs e)
   {
       Response.Cache.SetCacheability(HttpCacheability.NoCache);
       Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
       Response.Cache.SetNoStore();
   }
    protected void Page_Load(object sender, EventArgs e)//Enable Timer And Get Card Details
    {
        
        //carddetails = Request.QueryString["cardno"];
        //payamount = Request.QueryString["amount"];
        
        Label2.Visible = false;
        if (!IsPostBack)
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
                cardno = arrIndMsg[1].ToString().Trim();

                arrIndMsg = arrMsgs[1].Split('='); //Get the Amount
                payamount = arrIndMsg[1].ToString().Trim();

                arrIndMsg = arrMsgs[2].Split('='); //Get the Pin
                pin = arrIndMsg[1].ToString().Trim();

                arrIndMsg = arrMsgs[3].Split('='); //Get the expdate
                expdat = arrIndMsg[1].ToString().Trim();

                arrIndMsg = arrMsgs[4].Split('='); //Get the cvv
                cvv = arrIndMsg[1].ToString().Trim();

                arrIndMsg = arrMsgs[5].Split('='); //Get the transactiontype
                transtype = arrIndMsg[1].ToString().Trim();
               // Response.Write(carddetails + " " + payamount + " ");
                ViewState["TransactionTime"] = 10;
                Timer1.Enabled = true;
                //Label3.Text = "cardno=" + cardno + "payamount=" + payamount + "PIN=" + pin + "expdate=" + expdat + "cvv=" + cvv;
            }
            else
            {
                Response.Redirect(Userdata.ClientPageURL);
            }
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
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            makeTransaction();
        }
        catch(Exception ex)
        {
            Label2.Text = "Error in Transaction...";
            Label2.ForeColor = System.Drawing.Color.Red;
            Label2.Visible = false;
         
        }
    }

    private void makeTransaction() 
    {
        int i = Convert.ToInt32(ViewState["TransactionTime"]);
        if (i == 0)
        {
            
                      
            //Response.Redirect("DetailswithTransaction.aspx?carddetails=" + carddetails + "&payamount=" + payamount + "&transactno=" + txno);
            //generatepayment();
            string strURL = "DetailswithTransaction.aspx?";
            //  Response.Redirect("ConfirmTransaction.aspx?cardno=" + lblcrdno.Text+"&amount="+lblamt.Text);
            if (HttpContext.Current != null)
            {
               
                    paymentClass obj = new paymentClass();
                    i = 10;
                    if(obj.validateCredential(cardno, cvv, expdat, pin))
                    {
                        System.Random trnno = new System.Random((int)System.DateTime.Now.Ticks);
                        int txno = trnno.Next(1, 999999999);
                        //Random trnno = new Random();
                        //txno = trnno.Next(1, 999999999);
                        obj.makePayment(txno, cardno, cvv, expdat, pin, payamount, Userdata.ClientAccno);
                        string strURLWithData = strURL + EncryptQueryString(string.Format("cardno={0}&amount={1}&trnid={2}&transactionType={3}", cardno, payamount, txno, transtype));
                        HttpContext.Current.Response.Redirect(strURLWithData);
                    }
                    else
                    {
                        Response.Redirect(Userdata.ClientPageURL);
                    }
            }
            else
            { }
        }
        else
        {

            i--;
            ViewState["TransactionTime"] = i;
            Label1.Text = "Transaction Is Processing...Please Do Not Refresh ..." + i;
        }
    }
    void generatepayment()
    {
        string strURL = "DetailswithTransaction.aspx?";
        //  Response.Redirect("ConfirmTransaction.aspx?cardno=" + lblcrdno.Text+"&amount="+lblamt.Text);
        if (HttpContext.Current != null)
        {
            string strURLWithData = strURL + EncryptQueryString(string.Format("cardno={0}&amount={1}&trnid={2}",cardno,payamount,txno));
            HttpContext.Current.Response.Redirect(strURLWithData);
        }
        else
        { }
    }
}