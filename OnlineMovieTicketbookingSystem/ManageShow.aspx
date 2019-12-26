<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="ManageShow.aspx.cs" Inherits="UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="col-md-12" style="border-right: 1px dotted #C2C2C2;padding-right: 30px;">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs">
                               <li class="active"><a href="#Registration" data-toggle="tab">Add Show </a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content">
                            
                            <div role="form" class="form-horizontal">
                                <div class="form-group">
                                    <label for="Moviename" class="col-sm-2 control-label">
                                        Movie Name</label>
                                    <div class="col-sm-10">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <select class="form-control" id="MvdrpDwn" runat="server">
                                                  
                                                </select>
                                            </div>
                                            
                                        </div>
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label for="Moviename" class="col-sm-2 control-label">
                                        Theatre Name</label>
                                    <div class="col-sm-10">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <select class="form-control" id="TheatreName" runat="server">
                                                  
                                                </select>
                                            </div>
                                           
                                        </div>
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label for="Moviename" class="col-sm-2 control-label">
                                        Show Time</label>
                                    <div class="col-sm-10">
                                        <div class="row">
                                            <div class="col-md-3">
                                             <input type="time" id="showTime" runat="server" />
                                            </div>
                                            <div class="col-md-2">
                                             <select class="form-control" id="time" runat="server">
                                                  
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label for="Moviename" class="col-sm-2 control-label">
                                        No Of Seats</label>
                                    <div class="col-sm-10">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <select class="form-control" id="Seats" runat="server">
                                                  
                                                </select>
                                            </div>
                                          
                                        </div>
                                    </div>
                                </div>
                             
                                <div class="row">
                                    <div class="col-sm-2">
                                        <asp:Label ID="lblregitrationmesg" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-sm-10">
                                       
                                        <asp:Button ID="Btn_Submit" runat="server" Text="Add Show" CssClass="btn btn-primary btn-sm" OnClick="Btn_Submit_Click" />
                                       <asp:Button ID="Btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-primary btn-sm" OnClick="Btn_Cancel_Click"/>
                                    </div>
                                </div>
                                </div>
                        </div>
                       
                    </div>

</asp:Content>

