<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="SearchMovie.aspx.cs" Inherits="SearchMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="col-md-12" style="border-right: 1px dotted #C2C2C2;padding-right: 30px;">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs">
                               <li class="active"><a href="#Registration" data-toggle="tab">Search Movie</a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content">
                            
                            <div role="form" class="form-horizontal">
                                
                                <div class="form-group">
                                    <label for="email" class="col-sm-2 control-label">
                                        Movie Name</label>
                                    <div class="col-sm-10">
                                        <input type="text" class="form-control" id="MovieName" placeholder="Movie Name" runat="server" />
                                    </div>
                                </div>
                                 <div class="row">
                                    <div class="col-sm-2">
                                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-sm-10">
                                       
                                        <asp:Button ID="Btn_Submit" runat="server" Text="Search Movie" CssClass="btn btn-primary btn-sm" OnClick="Btn_Submit_Click"/>
                                       <asp:Button ID="btn_All" runat="server" Text="View All" CssClass="btn btn-primary btn-sm" OnClick="btn_All_Click"/>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-2">
                                      
                                    </div>
                                    <div class="col-sm-10">
                                    </div>
                                </div>
                                  <div class="row">
                                  
                                    <div class="col-sm-12">
                                       
                                        <asp:GridView ID="MovieGrid" runat="server" CssClass="table" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                                            <AlternatingRowStyle BackColor="#F7F7F7"></AlternatingRowStyle>

                                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C"></FooterStyle>

                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7"></HeaderStyle>

                                            <PagerStyle HorizontalAlign="Right" BackColor="#E7E7FF" ForeColor="#4A3C8C"></PagerStyle>

                                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C"></RowStyle>

                                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7"></SelectedRowStyle>

                                            <SortedAscendingCellStyle BackColor="#F4F4FD"></SortedAscendingCellStyle>

                                            <SortedAscendingHeaderStyle BackColor="#5A4C9D"></SortedAscendingHeaderStyle>

                                            <SortedDescendingCellStyle BackColor="#D8D8F0"></SortedDescendingCellStyle>

                                            <SortedDescendingHeaderStyle BackColor="#3E3277"></SortedDescendingHeaderStyle>
                                        </asp:GridView>
                                    </div>
                                </div>
                               </div>
                            </div>
                    </div>
</asp:Content>

