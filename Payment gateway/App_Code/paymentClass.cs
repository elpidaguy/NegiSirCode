using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;

/// <summary>
/// Summary description for paymentClass
/// </summary>
public class paymentClass
{
    //OracleConnection con = new OracleConnection(@"Data Source=dacpc;User ID=dac;Password=dac;Unicode=True");
    //OracleCommand cmd;
    //OracleDataAdapter oda;
    //DataTable dt;
    //DataSet ds;
   //static string connstring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\Payment gateway\App_Data\bank.mdf;Integrated Security=True;Connect Timeout=30";
    DataClassesDataContext da = new DataClassesDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\R\Payment gateway\Payment gateway\App_Data\bank.mdf';Integrated Security=True;Connect Timeout=30");
    public string makePayment(long tansactionid, string cardno, string cvvno, string expdate, string pin,string amount,string CardNoto)
    {
        string status = "fail";
        try
        {
            trnsc_tbl obj = new trnsc_tbl();
            var data = from allrec in da.card_details
                       where  allrec.cvv_no == cvvno
                       && allrec.expiry == expdate && allrec.pin == pin && allrec.card_no == cardno
                       select allrec;
            if (data.Any())
            {

                lock (obj)
                {
                    
                    foreach (card_detail rec in data)
                    {
                        if (Convert.ToInt32(rec.amount) > Convert.ToInt32(amount))
                            rec.amount = (Convert.ToInt32(rec.amount) - Convert.ToInt32(amount)).ToString();
                        else
                            return status;
                    }
                    obj.amount = amount;
                    obj.cardnofrom = cardno;
                    obj.txnid = tansactionid.ToString();
                    obj.cardnoto =CardNoto;
                    obj.status = "success";
                    obj.transaction_date = System.DateTime.Now.ToString();
                    status = "success";
                    da.trnsc_tbls.InsertOnSubmit(obj);
                    da.SubmitChanges();
                }

            }
            return status;
        }catch(Exception ex)
        {
            return status;
        }

        
    }
    public bool validateCredential(string cardno, string cvvno, string expdate, string pin)
    {
        bool status = false;
        var data = from allrec in da.card_details
                   where allrec.cvv_no==cvvno
                   && allrec.expiry==expdate && allrec.pin==pin && allrec.card_no==cardno
                   select allrec;
        if(data.Any())
        {
            status = true;
        }

        return status;
    }


}