<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmTransaction.aspx.cs" Inherits="ConfirmTransaction" %>

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
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                 <asp:Timer ID="Timer1" runat="server" Interval="500" OnTick="Timer1_Tick"></asp:Timer>
        <br />
                 <asp:Label ID="Label1" runat="server"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
       
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
       
    </div>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
