<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="BookedTicketHistory.aspx.cs" Inherits="BookedTicketHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function printDiv(divName) {
            debugger;
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
    <div class="t-c" >
		<div class="col-md-12" style="border-right: 1px dotted #C2C2C2;padding-right: 30px;">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs">
                               <li class="active"><a href="#Registration" data-toggle="tab">Booked Ticket History </a></li>
                        </ul>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Bookin_ID" OnRowCommand="grdCustomPagging_RowCommand" DataSourceID="LinqDataSource1" CssClass="table" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="2">
                <Columns>
                    <asp:BoundField DataField="Bookin_ID" HeaderText="Booking ID" ReadOnly="True" InsertVisible="False" SortExpression="Bookin_ID"></asp:BoundField>
                    <asp:BoundField DataField="ShowID" HeaderText="Show ID" SortExpression="ShowID"></asp:BoundField>
                    <asp:BoundField DataField="Booking_Date" HeaderText="Booking Date" SortExpression="Booking_Date"></asp:BoundField>
                    <asp:BoundField DataField="Movie_Date" HeaderText="Movie Date" SortExpression="Movie_Date"></asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                     <asp:TemplateField HeaderText="Print Ticket">
                            <ItemTemplate>
                           <asp:LinkButton runat="server" ID="lnkView" CommandArgument='<%#Eval("Bookin_ID") %>'
                             CommandName="VIEW">Print</asp:LinkButton>
                             </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Cancel Ticket">
                            <ItemTemplate>
                           <asp:LinkButton runat="server" ID="lnkCancel" CommandArgument='<%#Eval("Bookin_ID") %>'
                             CommandName="CANCEL">Cancel</asp:LinkButton>
                             </ItemTemplate>
                      </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099"></FooterStyle>

                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" ForeColor="#330099"></PagerStyle>

                <RowStyle BackColor="White" ForeColor="#330099"></RowStyle>

                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#FEFCEB"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#AF0101"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#F6F0C0"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#7E0000"></SortedDescendingHeaderStyle>
            </asp:GridView>
            <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="DataClassesDataContext" TableName="Book_Tickets" Where="Status == @Status && UserEmail == @UserEmail">
                <WhereParameters>
                    <asp:Parameter DefaultValue="Booked" Name="Status" Type="String"></asp:Parameter>
                    <asp:SessionParameter SessionField="UserEmail" Name="UserEmail" Type="String"></asp:SessionParameter>
                </WhereParameters>
            </asp:LinqDataSource>
       
         <asp:Label ID="lblmessg" runat="server" Text=""></asp:Label>
            <div id="print">
         <table class="table" runat="server" id="printTicket" runat="server">
                        <tr>
                            <td>Movie Name</td>
                            <td>
                                <asp:Label ID="MovieLbl" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Theatre Name</td>
                            <td>
                                <asp:Label ID="TheatrLbl" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Date</td>
                            <td>
                                <asp:Label ID="Date_lbl" runat="server"></asp:Label></td>
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
                                            <td>Total Amount</td><td>  <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                <tr>
                            <td>Payment Status</td>
                            <td><asp:Label ID="paymntStatus" runat="server" Text=""></asp:Label> </td>

                        </tr>
                        <tr>
                        <td>
                        </td>
                        <td>
                            <input type="button" onclick="printDiv('printTicket')" value="Print Ticket" class="btn btn-primary btn-sm" />
                        </td>
                        </tr>
                 
                    </table>
                </div>
            
</div>
</div>
</asp:Content>

