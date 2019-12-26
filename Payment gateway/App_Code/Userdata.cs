using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Userdata
/// </summary>
public class Userdata
{
    string txnid { get; set; }

    string status { get; set; }

    public static string ClientPageURL = "http://localhost:54745/GenerateTicket.aspx";

    public static string WalletPageURL = "http://localhost:54745/Wallet.aspx";
    public static string ClientAccno = "3245443343437887";
}