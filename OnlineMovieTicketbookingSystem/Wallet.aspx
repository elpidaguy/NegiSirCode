<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="Wallet.aspx.cs" Inherits="Wallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
$(document).ready(function(){
    $("#flip").click(function(){
        $("#panel").slideToggle("slow");
    });
});
</script>
    
<style>
#panel, #flip {
    padding: 5px;
    text-align: center;
    border: solid 1px #c3c3c3;
}

#panel {
    padding: 20px;
    display: none;
}
</style>
     <div class="t-c">
		<div class="tc" style="align-content:center; margin-left:20%;">
								     <h3 class="event-tab-head">My Wallet</h3>
									<table class="table" >
                        <tr>
                            <td>Wallet Amount</td>
                            <td>
                                <asp:Label ID="waletAmount" runat="server" Text=""></asp:Label></td>
                              <td>
                                <asp:Label ID="messg" runat="server" Text=""></asp:Label></td>
                        </tr>
 </table>
<input type="button" id="flip" value="Add Money" />
<div id="panel">
    <table class="table" >
                        <tr>
                            <td>Amount</td>
                            <td>
                                   <input type="number" class="form-control" id="Amount" placeholder="Amount" runat="server"/></td>
                        </tr>
         <tr>
                            <td><asp:Button ID="AddAmount" runat="server" Text="Add Amount" CssClass="btn btn-primary btn-sm" OnClick="AddAmount_Click"/></td>
                            <td>
                               <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="btn btn-primary btn-sm"/>   
                            </td>
                        </tr>
 </table>
                    
                           
                                
</div>

                     
                                
                      
                   

</div>
</div>
    
</asp:Content>

