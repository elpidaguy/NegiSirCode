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
public partial class transaction : System.Web.UI.Page
{
    private byte[] key = { };
    private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
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
            adddataToDeropdownlist();
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
                string amount = arrIndMsg[1].ToString().Trim();
                lblamt.Text = amount;

                arrIndMsg = arrMsgs[1].Split('='); //Get the Cardno
                string ttype = arrIndMsg[1].ToString().Trim();
                ViewState["transactionType"] = ttype;


            }
        }
      

    }
    private string DecryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
    }
   
    void adddataToDeropdownlist()
    {
        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        DropDownList1.Items.Add("MM");
        DropDownList2.Items.Add("YYYY");
        for (int i = 1; i < 13; i++)
        {
            if (i < 10)
            {
                DropDownList1.Items.Add("0"+i.ToString());
            }
            else
            {
                DropDownList1.Items.Add(i.ToString());
            }
        }
        for (int i = 2016; i < 2050; i++)
            DropDownList2.Items.Add(i.ToString());
    }
    void showdata()
    {
        lblexp.Text = DropDownList1.SelectedItem.Text + "-" + DropDownList2.SelectedItem.Text;
        lblcard.Text = DropDownList3.SelectedItem.Text;
        lblcrdno.Text = TextBox2.Text.Trim();
        ldlholder.Text = TextBox3.Text.Trim();
        HiddenField1.Value = TextBox5.Text.Trim();
        HiddenField2.Value = TextBox4.Text.Trim();
        lblcvv.Text = "***";
        lblatm.Text = "****";
        lblcard.Visible = true;
        lblcrdno.Visible = true;
        ldlholder.Visible = true;
        lblexp.Visible = true;
        lblcvv.Visible = true;
        lblexp.Visible = true;
        lblatm.Visible = true;
        DropDownList1.Visible = false;
        DropDownList2.Visible = false;
        DropDownList3.Visible = false;
        TextBox2.Visible = false;
        TextBox3.Visible = false;
        TextBox4.Visible = false;
        TextBox5.Visible = false;
        Button1.Text = "Confirm";
        Button2.Visible = true;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Button1.Text == "MakePayment")
            {
                showdata();
            }
            else if (Button1.Text == "Confirm")
            {
                ConfirmTransaction();
            }
        }
        catch(Exception ex)
        {
            Response.Write("<script>document.forms[0]['errdiv'].innerHTML='Server Maintenance'</script>");
        }

    }
     void retriveControls()
    {
        lblatm.Visible = false;
        lblcard.Visible = false;
        lblcrdno.Visible = false;
        ldlholder.Visible = false;
        lblcvv.Visible = false;
        lblexp.Visible = false;
        TextBox2.Visible = true;
        TextBox3.Visible = true;
        TextBox4.Visible = true;
        TextBox5.Visible = true;
        DropDownList1.Visible = true;
        DropDownList2.Visible = true;
        DropDownList3.Visible = true;
        Button1.Text = "MakePayment";
        Button2.Visible = false;
        TextBox2.Text = "";
        TextBox3.Text = "";

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
      if(Button1.Text=="Confirm")
        retriveControls();
    }
    void ConfirmTransaction()
    {
        string strURL = "ConfirmTransaction.aspx?";
      //  Response.Redirect("ConfirmTransaction.aspx?cardno=" + lblcrdno.Text+"&amount="+lblamt.Text);
        if (HttpContext.Current != null)
        {
            string transactiontyp = ViewState["transactionType"] as string;
            string strURLWithData = strURL + EncryptQueryString(string.Format("cardno={0}&amount={1}&atmpin={2}&expdate={3}&cvvno={4}&transactiontyp={5}", lblcrdno.Text, lblamt.Text, HiddenField1.Value, lblexp.Text, HiddenField2.Value, transactiontyp));
            Session["CardTyp"] = DropDownList3.SelectedItem.Text;
            HttpContext.Current.Response.Redirect(strURLWithData);
        }
        else
        { }
    }
    public string EncryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
    }
}