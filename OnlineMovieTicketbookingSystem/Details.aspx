<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="MovieDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="m-single-article">
		<div class="article-left">
			<h3><span>
                <asp:Label ID="lblmovie" runat="server" Text=""></asp:Label> <i class="fa fa-heart"></i> <asp:Label ID="lblLike" runat="server" Text=""></asp:Label>%</span></h3>
			<p><a class="m-green" href="#">Action</a></p>
			<div class="clearfix"></div>
			<div class="article-time-strip">
				<div class="article-time-strip-left">
					<p>Release Date <span><i class="fa fa-calendar"></i>
                        <asp:Label ID="lblRelease" runat="server" Text=""></asp:Label></span></p>
				</div>
				<div class="clearfix"></div>
				<div class="article-img">
					<iframe frameborder="0" allowfullscreen runat="server" id="movieTrailer"></iframe>
				</div>
				<div class="review-info">
								<h6 class="span88">
                                    <asp:Label ID="lblMovieName" runat="server" Text=""></asp:Label></h6>
								<p class="dirctr"><a href="">
                                    <asp:Label ID="lblDirector" runat="server" Text=""></asp:Label>, </a>
                                    <asp:Label ID="lblReleaseDate" runat="server" Text=""></asp:Label> IST</p>								
								<p class="ratingview">Critic's Rating:</p>
								<div class="rating">
									<span>☆</span>
									<span>☆</span>
									<span>☆</span>
									<span>☆</span>
									<span>☆</span>
								</div>
								<p class="ratingview">
								&nbsp;<asp:Label ID="lblRating" runat="server" Text=""></asp:Label>
								</p>
								<div class="clearfix"></div>							
								<div class="yrw">
									<div class="dropdown-button">           			
										<select class="dropdown" tabindex="9" data-settings="{&quot;wrapperClass&quot;:&quot;flat&quot;}" runat="server" id="drpDownRating">
										<option value="0">Your rating</option>	
										<option value="1">1(Poor)</option>
										<option value="2">1.5(Below average)</option>
										<option value="3">2(Average)</option>
										<option value="4">2.5(Above average)</option>
										<option value="5">3(Watchable)</option>
										<option value="6">3.5(Good)</option>
										<option value="7">4.5(Very good)</option>
										<option value="8">5(Outstanding)</option>
									  </select>
									</div>
									<div class="rtm text-center">
                                        <asp:Button ID="SubmitRating" runat="server" Text="Rate It" CssClass="btn-default" OnClick="SubmitRating_Click"/>
									</div>
									<div class="clearfix">
                                        <asp:Label ID="lblmesg" runat="server" Text=""></asp:Label>
									</div>
								</div>
								<p class="info"><strong>CAST</strong>: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCastData" runat="server" Text=""></asp:Label></p>
								<p class="info"><strong>DIRECTION</strong>: &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Director" runat="server" Text=""></asp:Label></p>
								<p class="info"><strong>STORY</strong>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblStory" runat="server" Text=""></asp:Label></p>
								
							</div>
			</div>
		</div>
		<div class="article-right" style="display:none;">
			<div class="grid_3 grid_5">
				   <div class="bs-example bs-example-tabs" role="tabpanel" data-example-id="togglable-tabs">
			<ul id="myTab" class="nav nav-tabs" role="tablist">
			  <li role="presentation" class="active"><a href="#home" id="home-tab" role="tab" data-toggle="tab" aria-controls="home" aria-expanded="true">Tue-30</a></li>
			  <li role="presentation"><a href="#profile" role="tab" id="profile-tab" data-toggle="tab" aria-controls="profile">WED-1</a></li>
			</ul>
			<div id="myTabContent" class="tab-content">
			  <div role="tabpanel" class="tab-pane fade in active" id="home" aria-labelledby="home-tab">				  
                 <p class="m-s-t">INOX: Lorem Mall, Chicago</p>
				 <a class="show-time" href="movie-select-show.html">06:30 PM</a>
				 <div class="clearfix"></div>
				  <a class="more-show-time" href="movie-select-show.html">More Show Times</a>
			  </div>
			  <div role="tabpanel" class="tab-pane fade" id="profile" aria-labelledby="profile-tab">
				 <p class="m-s-t">INOX: Lorem Mall, Chicago</p>
				 <a class="show-time" href="movie-select-show.html">12:45 PM</a><a class="show-time" href="movie-select-show.html">06:30 PM</a>
				 <div class="clearfix"></div>
				 <a class="more-show-time" href="movie-select-show.html">More Show Times</a>
			  </div>
			</div>
		   </div>
		  </div>
		</div>
		<div class="clearfix"></div>
	</div>
</asp:Content>

