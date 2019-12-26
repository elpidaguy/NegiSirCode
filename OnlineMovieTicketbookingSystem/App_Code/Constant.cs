using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Constant
/// </summary>
public class Constant
{
    public const string EmailUseEmail = "technotheatres@gmail.com";
    public const string EmailUserPassword = "Rupal@123";
    public const string SMTPClient = "smtp.gmail.com";
    public const string DefaultSubject = "Techno Theatres Greeting";
    public const string DefaultBody = "Congratulation to login In Techno Theatres happy to See Connection With you.";
    public const int ServerPort = 587;

    public static string EncryptionKey = "r0b1nr0y";

    public static string PaymentURL = "http://localhost:55297/validate.aspx?payamt=";
    public static string WalletURL = "http://localhost:55297/validate.aspx?";
}