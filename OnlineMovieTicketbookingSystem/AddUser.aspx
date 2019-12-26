<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="col-md-12" style="border-right: 1px dotted #C2C2C2;padding-right: 30px;">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs">
                               <li class="active"><a href="#Registration" data-toggle="tab">Add User</a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content">
                            
                            <div role="form" class="form-horizontal">
                                <div class="form-group">
                                    <label for="email" class="col-sm-2 control-label">
                                        Name</label>
                                    <div class="col-sm-10">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <select class="form-control" id="drpDwn" runat="server">
                                                    <option value="Mr">Mr.</option>
                                                    <option value="Ms">Ms.</option>
                                                    <option value="Mrs">Mrs.</option>
                                                </select>
                                            </div>
                                            <div class="col-md-9">
                                                <input type="text" class="form-control" placeholder="Name" runat="server" id="Name"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="email" class="col-sm-2 control-label">
                                        Email</label>
                                    <div class="col-sm-10">
                                        <input type="email" class="form-control" id="email" placeholder="Email" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="mobile" class="col-sm-2 control-label">
                                        Mobile</label>
                                    <div class="col-sm-10">
                                        <input type="number" class="form-control" id="mobile" placeholder="Mobile" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="password" class="col-sm-2 control-label">
                                        Password</label>
                                    <div class="col-sm-10">
                                        <input type="password" class="form-control" id="password" placeholder="Password" runat="server"/>
                                    </div>
                                </div>
                                 <div class="form-group">
                                     <label for="email" class="col-sm-2 control-label">
                                        User Type</label>
                                    <div class="col-sm-10">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="drpUserTyp" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                           
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-2">
                                        <asp:Label ID="lblregitrationmesg" runat="server" Text=""></asp:Label>
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

