<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Forgotpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="t-c" >
		<div class="col-md-12" style="border-right: 1px dotted #C2C2C2;padding-right: 30px;">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs">
                               <li class="active">Change Password</li>
                        </ul>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <asp:TextBox ID="Password" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                      
                                  
                                    </div>
                                      <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                       <asp:TextBox ID="ConfrmPassword" runat="server" CssClass="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                      
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <asp:Label ID="lbl_message" runat="server" Text=""></asp:Label>
                                      
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="pull-right">
                                            <asp:Button ID="btn_forgotpassword" runat="server" Text="Change Password" class="btn btn-primary small" OnClick="btn_forgotpassword_Click"/>
                                         
                                        </div>  
                                    </div>
									<div class="clearfix"></div>  
                 </div>
				<!-- end nav navbar-nav navbar-right -->
			</div>
     <br />
</asp:Content>

