using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Wallet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserEmail"] != null)
        {
            string Emailid = Convert.ToString(Session["UserEmail"]);
            var wallet = ConnectionClass.getWalletAmount(Emailid);
            foreach (var item in wallet)
            {
                waletAmount.Text = item.Amount.ToString();
                break;
            }

        }
        if (!IsPostBack)
        {
           
            string transstatus = Request.QueryString["status"];
            string transactionID = Request.QueryString["transId"];
            string UserEmail = Convert.ToString(Session["UserEmail"]);
            string Amount = Request.QueryString["amount"];
            if (!string.IsNullOrEmpty(transstatus) && !string.IsNullOrEmpty(transactionID) )
            {
                ConnectionClass.InsertTransaction(UserEmail, Amount, transstatus, transactionID);
                AddAmountToWallet(Amount);
            }
        }

     
    }
    protected void AddAmount_Click(object sender, EventArgs e)
    {
        string strURL = Constant.WalletURL;
        if (Convert.ToInt32(Amount.Value) > 0)
        {
            string strURLWithData = strURL + EncryptQueryString(string.Format("payamt={0}&transactionType=AddtoWallet", Amount.Value));
            Response.Redirect(strURLWithData);
        }
        else
        {
            messg.Text = "Please Enter Amount More than 0";
            messg.ForeColor = System.Drawing.Color.Red;
        }
        //AddAmountToWallet();
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
    private void AddAmountToWallet(string walletAmount)
    {
        string Emailid = Convert.ToString(Session["UserEmail"]);
        if (!string.IsNullOrEmpty(Emailid) && !string.IsNullOrEmpty(walletAmount))
        {
            int oldamount = 0;

            var wallet = ConnectionClass.getWalletAmount(Emailid);
            bool isWalletHasAmount = false;
            foreach (var item in wallet)
            {

                if (item.Amount != null)
                {
                    oldamount = Convert.ToInt32(item.Amount);
                    isWalletHasAmount = true;
                }

                break;

            }
            if (Convert.ToInt32(walletAmount) > 0 && oldamount > 0)
            {
                int newAmount = Convert.ToInt32(walletAmount) + oldamount;

                ConnectionClass.UpdateWallet(Emailid, (newAmount));
                messg.Text = "Amount Updated to Your Wallet Successfully";
                messg.ForeColor = System.Drawing.Color.Green;
            }
            else if (!isWalletHasAmount)
            {
                ConnectionClass.AddWalet(Emailid, Convert.ToInt32(walletAmount));
                messg.Text = "Amount Added to Your Wallet Successfully";
                messg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                messg.Text = "You Cant Add Money of Lesser than 0 Amount";
                messg.ForeColor = System.Drawing.Color.Red;
            }

        }
    }
}