<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="GenerateTicket.aspx.cs" Inherits="GenerateTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
     <div class="t-c" >
		<div class="tc" style="align-content:center; margin-left:20%;" id="printTicket">
								     <h3 class="event-tab-head">ETicket</h3>
									<table class="table" >
                        <tr>
                            <td>Movie Name</td>
                            <td>
                                <asp:Label ID="MovieLbl" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Theatre Name</td>
                            <td>
                                <asp:Label ID="TheatrLbl" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Date</td>
                            <td>
                                <asp:Label ID="Date_lbl" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                                        <tr>
                                            <td>
                                                Selected Seat
                                            </td><td>
                                                <asp:Label ID="lblSeats" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                          <tr>
                                            <td>Amount</td><td>  <asp:Label ID="lblAmt" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                          <tr>
                                            <td>Service Tax</td><td>  <asp:Label ID="lblServiceTax" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                          <tr>
                                            <td>Grand Total</td><td>  <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                <tr>
                            <td>Payment Status</td>
                            <td><asp:Label ID="paymntStatus" runat="server" Text=""></asp:Label> </td>
                        </tr>
                                        <tr>
                                            <td colspan="2">
                                             <asp:Label ID="msg" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td colspan="2">
                                                 <input type="button" onclick="printDiv('printTicket')" value="Print Ticket" class="btn btn-primary btn-sm"/>
                                            </td>
                                        </tr>
                    </table>
           
</div>
</div>
</asp:Content>

