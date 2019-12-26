<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserConfirmBooking.aspx.cs" Inherits="ConfirmBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="t-c">
		<div class="tc" style="align-content:center; margin-left:20%;">
								     <h3 class="event-tab-head">Confirm &amp; Booking</h3>
									<table class="table" >
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
                            <td>
                                <asp:Button ID="Continue" runat="server" Text="Make Payment" CssClass="btn btn-primary btn-sm" OnClick="Continue_Click"/></td>
                            <td>
                                <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="btn btn-primary btn-sm" OnClick="Cancel_Click"/></td>
                        </tr>
                    </table>

						    	</div>
	</div>
    
</asp:Content>

