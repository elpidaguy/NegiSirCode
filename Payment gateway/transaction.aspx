<%@ Page Language="C#" AutoEventWireup="true" CodeFile="transaction.aspx.cs" Inherits="transaction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>
        <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>

    <script src="js/jquery.min.js"></script>
    <script>
        function validate()
        {
            var cardnumber = document.forms[0]["TextBox2"].value;
            var holdername = document.forms[0]["TextBox3"].value;

            var cvv = document.forms[0]["TextBox4"].value;
            var pin = document.forms[0]["TextBox5"].value;
            var crdtyp = document.forms[0]["DropDownList3"].value;
            var mnth = document.forms[0]["DropDownList1"].value;
            var year = document.forms[0]["DropDownList2"].value;
            var errordiv = document.forms[0]["errdiv"];
            errdiv.style.color = "Red";
            if (cardnumber != "" && holdername != "" && cvv != "" && pin != "") {
                if (crdtyp == "---Select---") {
                    errdiv.innerHTML = "Select Card Type";
                    return false;
                }
               
                if (isNaN(cardnumber)) {
                    errdiv.innerHTML = "Card number Must be Numeric";
                    return false;
                }
                if (cardnumber.length<15) {
                    errdiv.innerHTML = "Card Should be 15 Digit";
                    return false;
                }
                if (mnth == "MM") {
                    errdiv.innerHTML = "Select Month";
                    return false;
                }
                if (year == "YYYY") {
                    errdiv.innerHTML = "Select Year";
                    return false;
                }
                if (isNaN(cvv)) {
                    errdiv.innerHTML = "CVV number Must be Numeric";
                    return false;
                }
                if (isNaN(pin)) {
                    errdiv.innerHTML = "PIN number Must be Numeric";
                    return false;
                }
                else {
                    return true;
                    errdiv.style.color = "Green";
                }

            }

            else {
                errdiv.innerHTML = "Enter Details Properly";
                return false;
            }
        }
      
    </script>
      <script type="text/javascript" language="javascript">

          function DisableBackButton() {
              window.history.forward()
          }
          DisableBackButton();
          window.onload = DisableBackButton;
          window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
          window.onunload = function () { void (0) }
     </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return validate()">
<div class="e-payment-section">
<div class="col-md-8 payment-left">
    <div style="width:70%;margin-left:10%;margin-top:10%;">
        <fieldset>
            <legend>
                <img src="imges/payment.png" />
            </legend>
        <table class="auto-style1">
            <tr>
                <td>
                    <img src="imges/secure_payment_by_paypal.jpg" style="height: 111px; width: 354px"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Amount</td>
                <td>
                    <asp:Label ID="lblamt" runat="server" Text="lblamt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Card Type</td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem>VISA</asp:ListItem>
                        <asp:ListItem>MasterCard</asp:ListItem>
                        <asp:ListItem>Maestro</asp:ListItem>
                        <asp:ListItem>RupayDebitCard</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblcard" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Card Number</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" MaxLength="15"></asp:TextBox>
                    <asp:Label ID="lblcrdno" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Card Holder Name</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <asp:Label ID="ldlholder" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Expiry Date</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>MM</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>YYYY</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblexp" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>CVV No.</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" ToolTip="Three Digit Number Behind the Card" MaxLength="3"></asp:TextBox>
                    <asp:Label ID="lblcvv" runat="server" Text="Label" Visible="False"></asp:Label>
                    <br />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                </td>
            </tr>
            <tr>
                <td>ATM PIN</td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" MaxLength="4"></asp:TextBox>
                    <asp:Label ID="lblatm" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" Visible="False" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="MakePayment" />
&nbsp;<asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" Visible="False" />
                 
                </td>
            </tr>
        </table>
    <div id="errdiv"></div>
            </fieldset>
    </div>
                </div>
    </div>
    </form>
</body>
</html>
