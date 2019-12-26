<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailswithTransaction.aspx.cs" Inherits="DetailswithTransaction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.min.js"></script>
    <script type="text/javascript" language="javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }

        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
     </script>
</head>
<body>
    <form id="form1" runat="server">
      <div class="t-c" >
		<div class="tc" style="align-content:center; margin-left:20%;" id="printTicket">
            <h3 class="event-tab-head">Payment Details</h3>
            <table class="table">
                <tr>
                    <td>Card Type : </td>
                    <td>
                        <asp:Label ID="cardtyp" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Transaction Type :</td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Purchase"></asp:Label></td>
                </tr>
                <tr>
                    <td>Card Number: </td>
                    <td>
                        <asp:Label ID="lblCard" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Amount: </td>
                    <td>
                        <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Transaction Id :</td>
                    <td>
                        <asp:Label ID="lblTransactioID" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Status :</td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2"><strong>Note: This is System Generated Slip</strong></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="msg" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <input type="button" onclick="printDiv('printTicket')" value="Print Reciept" class="btn-success" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">This page is Automatically destroyed After 5 second  Please Save transaction Id & Do not Refresh
                    </td>
                </tr>               
            </table>
           
        </div>


    </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                 <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" Enabled="False"></asp:Timer>
                 
            </ContentTemplate>
        </asp:UpdatePanel>
      

    </form>
</body>
</html>
