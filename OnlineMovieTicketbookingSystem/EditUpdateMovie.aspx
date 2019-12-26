<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="EditUpdateMovie.aspx.cs" Inherits="EditUpdateMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="col-md-12" style="border-right: 1px dotted #C2C2C2;padding-right: 30px;">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs">
                               <li class="active"><a href="#Registration" data-toggle="tab">Quick Edit Update Movie</a></li>
                        </ul>
          <asp:ListView ID="ListView1" runat="server" DataSourceID="LinqDataSource1" DataKeyNames="MovieID">
              <AlternatingItemTemplate>
                  <tr style="background-color: #FAFAD2; color: #284775;">
                      <td>
                          <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                          <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                      </td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieID") %>' runat="server" ID="MovieIDLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieName") %>' runat="server" ID="MovieNameLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Director") %>' runat="server" ID="DirectorLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Release_Date") %>' runat="server" ID="Release_DateLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieImage") %>' runat="server" ID="MovieImageLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Status") %>' runat="server" ID="StatusLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieTrailer") %>' runat="server" ID="MovieTrailerLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieTyp") %>' runat="server" ID="MovieTypLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Cast") %>' runat="server" ID="CastLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Story") %>' runat="server" ID="StoryLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Likes") %>' runat="server" ID="LikesLabel" /></td>
                  </tr>
              </AlternatingItemTemplate>
              <EditItemTemplate>
                  <tr style="background-color: #FFCC66; color: #000080;">
                      <td>
                          <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                          <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                      </td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieID") %>' runat="server" ID="MovieIDLabel1" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("MovieName") %>' runat="server" ID="MovieNameTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Description") %>' runat="server" ID="DescriptionTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Director") %>' runat="server" ID="DirectorTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Release_Date") %>' runat="server" ID="Release_DateTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("MovieImage") %>' runat="server" ID="MovieImageTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Status") %>' runat="server" ID="StatusTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("MovieTrailer") %>' runat="server" ID="MovieTrailerTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("MovieTyp") %>' runat="server" ID="MovieTypTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Cast") %>' runat="server" ID="CastTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Story") %>' runat="server" ID="StoryTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Likes") %>' runat="server" ID="LikesTextBox" /></td>
                  </tr>
              </EditItemTemplate>
              <EmptyDataTemplate>
                  <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                      <tr>
                          <td>No data was returned.</td>
                      </tr>
                  </table>
              </EmptyDataTemplate>
              <InsertItemTemplate>
                  <tr style="">
                      <td>
                          <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                          <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                      </td>
                      <td>&nbsp;</td>
                      <td>
                          <asp:TextBox Text='<%# Bind("MovieName") %>' runat="server" ID="MovieNameTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Description") %>' runat="server" ID="DescriptionTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Director") %>' runat="server" ID="DirectorTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Release_Date") %>' runat="server" ID="Release_DateTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("MovieImage") %>' runat="server" ID="MovieImageTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Status") %>' runat="server" ID="StatusTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("MovieTrailer") %>' runat="server" ID="MovieTrailerTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("MovieTyp") %>' runat="server" ID="MovieTypTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Cast") %>' runat="server" ID="CastTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Story") %>' runat="server" ID="StoryTextBox" /></td>
                      <td>
                          <asp:TextBox Text='<%# Bind("Likes") %>' runat="server" ID="LikesTextBox" /></td>
                  </tr>
              </InsertItemTemplate>
              <ItemTemplate>
                  <tr style="background-color: #FFFBD6; color: #333333;">
                      <td>
                          <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                          <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                      </td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieID") %>' runat="server" ID="MovieIDLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieName") %>' runat="server" ID="MovieNameLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Director") %>' runat="server" ID="DirectorLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Release_Date") %>' runat="server" ID="Release_DateLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieImage") %>' runat="server" ID="MovieImageLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Status") %>' runat="server" ID="StatusLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieTrailer") %>' runat="server" ID="MovieTrailerLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieTyp") %>' runat="server" ID="MovieTypLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Cast") %>' runat="server" ID="CastLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Story") %>' runat="server" ID="StoryLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Likes") %>' runat="server" ID="LikesLabel" /></td>
                  </tr>
              </ItemTemplate>
              <LayoutTemplate>
                  <table runat="server">
                      <tr runat="server">
                          <td runat="server">
                              <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                  <tr runat="server" style="background-color: #FFFBD6; color: #333333;">
                                      <th runat="server"></th>
                                      <th runat="server">MovieID</th>
                                      <th runat="server">MovieName</th>
                                      <th runat="server">Description</th>
                                      <th runat="server">Director</th>
                                      <th runat="server">Release_Date</th>
                                      <th runat="server">MovieImage</th>
                                      <th runat="server">Status</th>
                                      <th runat="server">MovieTrailer</th>
                                      <th runat="server">MovieTyp</th>
                                      <th runat="server">Cast</th>
                                      <th runat="server">Story</th>
                                      <th runat="server">Likes</th>
                                  </tr>
                                  <tr runat="server" id="itemPlaceholder"></tr>
                              </table>
                          </td>
                      </tr>
                      <tr runat="server">
                          <td runat="server" style="text-align: center; background-color: #FFCC66; font-family: Verdana, Arial, Helvetica, sans-serif; color: #333333;">
                              <asp:DataPager runat="server" ID="DataPager1">
                                  <Fields>
                                      <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                                  </Fields>
                              </asp:DataPager>
                          </td>
                      </tr>
                  </table>
              </LayoutTemplate>
              <SelectedItemTemplate>
                  <tr style="background-color: #FFCC66; font-weight: bold; color: #000080;">
                      <td>
                          <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                          <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                      </td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieID") %>' runat="server" ID="MovieIDLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieName") %>' runat="server" ID="MovieNameLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Director") %>' runat="server" ID="DirectorLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Release_Date") %>' runat="server" ID="Release_DateLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieImage") %>' runat="server" ID="MovieImageLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Status") %>' runat="server" ID="StatusLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieTrailer") %>' runat="server" ID="MovieTrailerLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("MovieTyp") %>' runat="server" ID="MovieTypLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Cast") %>' runat="server" ID="CastLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Story") %>' runat="server" ID="StoryLabel" /></td>
                      <td>
                          <asp:Label Text='<%# Eval("Likes") %>' runat="server" ID="LikesLabel" /></td>
                  </tr>
              </SelectedItemTemplate>
          </asp:ListView>
          <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="DataClassesDataContext" EnableDelete="True" EnableUpdate="True" TableName="Movie_Tbls"></asp:LinqDataSource>
      </div>
    <br />
</asp:Content>

