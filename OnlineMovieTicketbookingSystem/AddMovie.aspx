<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddMovie.aspx.cs" Inherits="UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="col-md-12" style="border-right: 1px dotted #C2C2C2;padding-right: 30px;">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs">
                               <li class="active"><a href="#Registration" data-toggle="tab">Add Movie</a></li>
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
                                <div class="form-group">
                                    <label for="mobile" class="col-sm-2 control-label">
                                        Description</label>
                                    <div class="col-sm-10">
                                        <input type="text" class="form-control" id="Description" placeholder="Description" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="password" class="col-sm-2 control-label">
                                        Director</label>
                                    <div class="col-sm-10">
                                        <input type="text" class="form-control" id="Director" placeholder="Director" runat="server"/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="Cast" class="col-sm-2 control-label">
                                        Cast</label>
                                    <div class="col-sm-10">
                                        <input type="text" class="form-control" id="Cast" placeholder="Cast" runat="server"/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="Story" class="col-sm-2 control-label">
                                        Story</label>
                                    <div class="col-sm-10">
                                        <input type="text" class="form-control" id="Story" placeholder="Story" runat="server"/>
                                    </div>
                                </div>
                                <div class="form-group">
                                     <label for="Release_Date" class="col-sm-2 control-label">
                                        Release Date</label>
                                    <div class="col-sm-10">
                                        <div class="row">

                                            <div class="col-md-3">
                                                 <input type="date" class="form-control" id="Release_Date" placeholder="dd-mm-yyyy" runat="server"/>
                                            </div>
                                           
                                        </div>
                                    </div>
                                   
                                </div>
                                <div class="form-group">
                                    <label for="password" class="col-sm-2 control-label">
                                        Movie Image</label>
                                    <div class="col-sm-10">
                                        <asp:FileUpload ID="MovieImg" runat="server" />Upload Movie Image in 666X235 size for better resolution 
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="password" class="col-sm-2 control-label">
                                        Movie Trailer</label>
                                    <div class="col-sm-10">
                                         <asp:FileUpload ID="Movie_trailer" runat="server" />Upload Movie Trailer leass than 2 MB for better performance
                                    </div>
                                </div>
                                 <div class="form-group">
                                     <label for="MovieTyp" class="col-sm-2 control-label">
                                        Movie Type</label>
                                    <div class="col-sm-10">
                                        <div class="row">

                                            <div class="col-md-3">
                                                <asp:DropDownList ID="drpMovieTyp" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                           
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-2">
                                        <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-sm-10">
                                       
                                        <asp:Button ID="Btn_Submit" runat="server" Text="Add Movie" CssClass="btn btn-primary btn-sm" OnClick="Btn_Submit_Click" />
                                       <asp:Button ID="Btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-primary btn-sm" OnClick="Btn_Cancel_Click"/>
                                    </div>
                                </div>
                                </div>
                        </div>
                       
                    </div>

</asp:Content>

