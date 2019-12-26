<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddTheatre.aspx.cs" Inherits="UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="col-md-12" style="border-right: 1px dotted #C2C2C2;padding-right: 30px;">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs">
                               <li class="active"><a href="#Registration" data-toggle="tab">Add Theatre</a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content">
                            
                            <div role="form" class="form-horizontal">
                                <div class="form-group">
                                    <label for="email" class="col-sm-2 control-label">
                                       Theatre Name</label>
                                    <div class="col-sm-10">
                                        <div class="row">
                                           
                                            <div class="col-md-12">
                                                <input type="text" class="form-control" placeholder="Theatre Name" runat="server" id="theatreName"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="email" class="col-sm-2 control-label">
                                        Area</label>
                                    <div class="col-sm-10">
                                        <input type="text" class="form-control" id="Area" placeholder="Area" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="mobile" class="col-sm-2 control-label">
                                        Address</label>
                                    <div class="col-sm-10">
                                        <input type="text" class="form-control" id="Address" placeholder="Address" runat="server" />
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="col-sm-2">
                                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-sm-10">
                                       
                                        <asp:Button ID="Btn_Submit" runat="server" Text="Add User" CssClass="btn btn-primary btn-sm" OnClick="Btn_Submit_Click" />
                                       <asp:Button ID="Btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-primary btn-sm" OnClick="Btn_Cancel_Click"/>
                                    </div>
                                </div>
                                </div>
                        </div>
                       
                    </div>

</asp:Content>

