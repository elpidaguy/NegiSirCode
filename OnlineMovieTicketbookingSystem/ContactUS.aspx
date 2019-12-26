<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUS.aspx.cs" Inherits="ContactUS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="defaultmenu" class="navbar-collapse collapse">
               <!-- end nav navbar-nav -->
                <div id="contact1" action="#" name="contactform" method="post">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="margin-top:1%;">
                                        <asp:TextBox ID="name" runat="server" CssClass="form-control" placeholder="Name" required></asp:TextBox>
                                        
                                       
                                    </div>
                     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="margin-top:1%;">
                         <asp:TextBox ID="email" runat="server" CssClass="form-control" placeholder="Email" required></asp:TextBox>
                         </div>
                     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="margin-top:1%;">
                          <asp:TextBox ID="phone" runat="server" CssClass="form-control" placeholder="Phone"></asp:TextBox>
                         </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="margin-top:1%;">
                                         
                                        <asp:TextBox ID="subject" runat="server" CssClass="form-control" placeholder="subject"></asp:TextBox>
                                      
                                    </div>                 
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="margin-top:1%;">
                                          <asp:TextBox ID="comments" runat="server" CssClass="form-control" placeholder="Your Message ..." TextMode="MultiLine"></asp:TextBox>
                                    </div>   
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="margin-top:1%;">
                                        <asp:Label ID="lbl_message" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="margin-top:1%;">
                                        <div class="pull-right">
                                            <asp:Button ID="Send" runat="server" Text="Submit" CssClass="btn btn-primary small" OnClick="Send_Click"/>
                                           <asp:Button ID="Btn_Cancel" runat="server" Text="Submit" CssClass="btn btn-primary small" OnClick="Btn_Cancel_Click"/>
                                        </div>  
                                    </div>
									<div class="clearfix"></div>  
                                </div>
				<!-- end nav navbar-nav navbar-right -->
			</div>
</asp:Content>

