<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BankAdmin.aspx.cs" Inherits="BankAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="LinqDataSource1">
            <AlternatingItemTemplate>
                <tr style="background-color: #FFFFFF;color: #284775;">
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="card_noLabel" runat="server" Text='<%# Eval("card_no") %>' />
                    </td>
                    <td>
                        <asp:Label ID="card_typeLabel" runat="server" Text='<%# Eval("card_type") %>' />
                    </td>
                    <td>
                        <asp:Label ID="amountLabel" runat="server" Text='<%# Eval("amount") %>' />
                    </td>
                    <td>
                        <asp:Label ID="expiryLabel" runat="server" Text='<%# Eval("expiry") %>' />
                    </td>
                    <td>
                        <asp:Label ID="pinLabel" runat="server" Text='<%# Eval("pin") %>' />
                    </td>
                    <td>
                        <asp:Label ID="card_holderLabel" runat="server" Text='<%# Eval("card_holder") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cvv_noLabel" runat="server" Text='<%# Eval("cvv_no") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color: #999999;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="card_noTextBox" runat="server" Text='<%# Bind("card_no") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="card_typeTextBox" runat="server" Text='<%# Bind("card_type") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="amountTextBox" runat="server" Text='<%# Bind("amount") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="expiryTextBox" runat="server" Text='<%# Bind("expiry") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="pinTextBox" runat="server" Text='<%# Bind("pin") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="card_holderTextBox" runat="server" Text='<%# Bind("card_holder") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="cvv_noTextBox" runat="server" Text='<%# Bind("cvv_no") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="card_noTextBox" runat="server" Text='<%# Bind("card_no") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="card_typeTextBox" runat="server" Text='<%# Bind("card_type") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="amountTextBox" runat="server" Text='<%# Bind("amount") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="expiryTextBox" runat="server" Text='<%# Bind("expiry") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="pinTextBox" runat="server" Text='<%# Bind("pin") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="card_holderTextBox" runat="server" Text='<%# Bind("card_holder") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="cvv_noTextBox" runat="server" Text='<%# Bind("cvv_no") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color: #E0FFFF;color: #333333;">
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="card_noLabel" runat="server" Text='<%# Eval("card_no") %>' />
                    </td>
                    <td>
                        <asp:Label ID="card_typeLabel" runat="server" Text='<%# Eval("card_type") %>' />
                    </td>
                    <td>
                        <asp:Label ID="amountLabel" runat="server" Text='<%# Eval("amount") %>' />
                    </td>
                    <td>
                        <asp:Label ID="expiryLabel" runat="server" Text='<%# Eval("expiry") %>' />
                    </td>
                    <td>
                        <asp:Label ID="pinLabel" runat="server" Text='<%# Eval("pin") %>' />
                    </td>
                    <td>
                        <asp:Label ID="card_holderLabel" runat="server" Text='<%# Eval("card_holder") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cvv_noLabel" runat="server" Text='<%# Eval("cvv_no") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                    <th runat="server">Id</th>
                                    <th runat="server">card_no</th>
                                    <th runat="server">card_type</th>
                                    <th runat="server">amount</th>
                                    <th runat="server">expiry</th>
                                    <th runat="server">pin</th>
                                    <th runat="server">card_holder</th>
                                    <th runat="server">cvv_no</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="card_noLabel" runat="server" Text='<%# Eval("card_no") %>' />
                    </td>
                    <td>
                        <asp:Label ID="card_typeLabel" runat="server" Text='<%# Eval("card_type") %>' />
                    </td>
                    <td>
                        <asp:Label ID="amountLabel" runat="server" Text='<%# Eval("amount") %>' />
                    </td>
                    <td>
                        <asp:Label ID="expiryLabel" runat="server" Text='<%# Eval("expiry") %>' />
                    </td>
                    <td>
                        <asp:Label ID="pinLabel" runat="server" Text='<%# Eval("pin") %>' />
                    </td>
                    <td>
                        <asp:Label ID="card_holderLabel" runat="server" Text='<%# Eval("card_holder") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cvv_noLabel" runat="server" Text='<%# Eval("cvv_no") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="DataClassesDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="card_details">
        </asp:LinqDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" DataSourceID="LinqDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="card_no" HeaderText="card_no" SortExpression="card_no" />
                <asp:BoundField DataField="card_type" HeaderText="card_type" SortExpression="card_type" />
                <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
                <asp:BoundField DataField="expiry" HeaderText="expiry" SortExpression="expiry" />
                <asp:BoundField DataField="pin" HeaderText="pin" SortExpression="pin" />
                <asp:BoundField DataField="card_holder" HeaderText="card_holder" SortExpression="card_holder" />
                <asp:BoundField DataField="cvv_no" HeaderText="cvv_no" SortExpression="cvv_no" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <br />
    </div>
    </form>
</body>
</html>
